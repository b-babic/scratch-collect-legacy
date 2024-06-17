using AutoMapper;
using Microsoft.Extensions.Options;
using scratch_collect.API.Database;
using scratch_collect.API.Exceptions;
using scratch_collect.API.Helper;
using scratch_collect.Model;
using scratch_collect.Model.Requests;
using Stripe;
using System;
using System.Linq;

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
            StripeConfiguration.ApiKey = _stripeKey;

            // Create the PaymentIntent
            var paymentIntentInfo = CreatePaymentIntentOptions(request.Amount);

            var service = new PaymentIntentService();
            var paymentIntent = service.Create(paymentIntentInfo);

            return new PaymentDetailsDTO()
            {
                PaymentAmount = paymentIntent.Amount,
                CreatedOn = DateTime.Now,
                Currency = paymentIntentInfo.Currency,
                InvoiceId = paymentIntent.InvoiceId,
                PaymentIntentId = paymentIntent.Id,
                PaymentMethodId = paymentIntent.PaymentMethodId
            };
        }

        private PaymentIntentCreateOptions CreatePaymentIntentOptions(double amount)
        {
            var createOptions = new PaymentIntentCreateOptions
            {
                Amount = (long?)amount * 100,
                Currency = "EUR",
                PaymentMethod = "pm_card_visa",
            };

            return createOptions;
        }
    }
}
