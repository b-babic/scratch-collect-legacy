using AutoMapper;
using Microsoft.Extensions.Options;
using scratch_collect.API.Database;
using scratch_collect.API.Exceptions;
using scratch_collect.API.Helper;
using scratch_collect.Model;
using scratch_collect.Model.Requests;
using Stripe;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Threading.Tasks;

namespace scratch_collect.API.Services
{
    public class PaymentService : IPaymentService
    {
        private readonly ScratchCollectContext _context;
        private readonly IMapper _mapper;
        private string _stripeKey;

        public PaymentService(ScratchCollectContext context, IMapper mapper, IOptions<AppSettings> settings)
        {
            _context = context;
            _mapper = mapper;
            _stripeKey = settings.Value.StripeKey;
        }

        public PaymentDetailsDTO ProcessPayment(PaymentBuyRequest request)
        {
            if (request.UserId == null)
                throw new BadRequestException("User id is required !");

            StripeConfiguration.ApiKey = _stripeKey;

            PaymentMethod paymentMethod = CreatePaymentMethod(request);

            if (paymentMethod.Id != null)
            {
                // Create the PaymentIntent
                var paymentIntentInfo = CreatePaymentIntent(request.Amount, paymentMethod.Id);

                return new PaymentDetailsDTO()
                {
                    PaymentAmount = paymentIntentInfo.Amount,
                    CreatedOn = DateTime.Now,
                    Currency = paymentIntentInfo.Currency,
                    InvoiceId = paymentIntentInfo.InvoiceId,
                    PaymentIntentId = paymentIntentInfo.Id,
                    PaymentMethodId = paymentIntentInfo.PaymentMethodId
                };
            }

            return null;
        }

        private PaymentIntent CreatePaymentIntent(double amount, string paymentMethodId)
        {
            var createOptions = new PaymentIntentCreateOptions
            {
                PaymentMethod = paymentMethodId,
                Amount = (long?)amount * 100,
                Currency = "eur",
            };

            PaymentIntentService paymentIntentService = new PaymentIntentService();

            try
            {
                PaymentIntent paymentIntent = paymentIntentService.Create(createOptions);

                if (paymentIntent.Id != null)
                {
                    var confirmOptions = new PaymentIntentConfirmOptions { };

                    paymentIntent = paymentIntentService.Confirm(
                        paymentIntent.Id,
                        confirmOptions
                    );

                    return paymentIntent;
                }
            }
            catch (Exception e)
            {
                throw new BadRequestException(String.Format("{0}", e.Message));
            }

            return null;
        }

        private PaymentMethod CreatePaymentMethod(PaymentBuyRequest request)
        {
            var paymentMethodOptions = new PaymentMethodCreateOptions
            {
                Type = "card",
                Card = new PaymentMethodCardOptions
                {
                    Number = request.CardNumber,
                    ExpMonth = GetExpMonth(request.ExpiryDate),
                    ExpYear = GetExpYear(request.ExpiryDate),
                    Cvc = request.CVV,
                },
            };

            var paymentMethodService = new PaymentMethodService();

            try
            {
                PaymentMethod paymentMethod = paymentMethodService.Create(paymentMethodOptions);
                return paymentMethod;
            }
            catch (Exception e)
            {
                throw new BadRequestException(String.Format("{0}", e.Message));
            }
        }

        private int GetExpMonth(string expDate)
        {
            return int.Parse(expDate.Split("/").First());
        }

        private int GetExpYear(string expDate)
        {
            return int.Parse(expDate.Split("/").Last());
        }
    }
}