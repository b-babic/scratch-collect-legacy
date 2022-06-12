using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using scratch_collect.API.Services;
using scratch_collect.Model;
using scratch_collect.Model.Requests;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace scratch_collect.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CouponController : Controller
    {
        private readonly ICouponService _couponService;
        private readonly IPaymentService _paymentService;
        private readonly IUserService _userService;
        private readonly IWalletService _walletService;

        public CouponController(ICouponService service, IPaymentService paymentService, IUserService userService, IWalletService walletService)
        {
            _userService = userService;
            _couponService = service;
            _paymentService = paymentService;
            _walletService = walletService;
        }

        [Authorize(Roles = "Administrator")]
        [HttpGet]
        [Route("all")]
        public ICollection<MerchantDTO> Get([FromQuery] CouponSearchRequest request)
        {
            return _couponService.GetAll(request);
        }

        [Authorize(Roles = "Administrator")]
        [HttpDelete("{id:int}")]
        public void Delete(int id)
        {
            _couponService.Delete(id);
        }

        [Authorize(Roles = "Administrator")]
        [HttpPost]
        [Route("generate")]
        public Task<bool> Generate(CouponGenerateRequest request)
        {
            return _couponService.Generate(request);
        }

        // Payments and wallets integration
        [Authorize(Roles = "Client")]
        [HttpPost]
        [Route("use")]
        public WalletDTO Use(CouponUseRequest request)
        {
            return _couponService.Use(request);
        }

        [Authorize(Roles = "Client")]
        [HttpPost]
        [Route("buy")]
        public WalletDTO Buy(PaymentBuyRequest request)
        {
            var processedPayment = _paymentService.ProcessPayment(request);

            if(processedPayment != null) {
                // Convert to Euros / tokens
                var amount = (double)processedPayment.PaymentAmount / 100;

                var user = _userService.GetById(request.UserId);

                if(user != null) {
                    return _walletService.AddBalance(user.Wallet.Id, amount);
                }
            }

            return null;
        }
    }
}