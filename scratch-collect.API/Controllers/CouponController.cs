using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using scratch_collect.API.Services;
using scratch_collect.Model;
using scratch_collect.Model.Requests;
using System.Collections.Generic;

namespace scratch_collect.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CouponController : Controller
    {
        private readonly ICouponService _couponService;

        public CouponController(ICouponService service)
        {
            _couponService = service;
        }

        [Authorize(Roles = "Administrator")]
        [HttpGet]
        [Route("all")]
        public ICollection<CouponDTO> Get([FromQuery] CouponSearchRequest request)
        {
            // Return all coupons
            // Optionally include filter and filter for used ones ?
            return _couponService.GetAll(request);
        }

        [Authorize(Roles = "Administrator")]
        [HttpDelete("{id:int}")]
        [Route("delete")]
        public void Delete(int id)
        {
            _couponService.Delete(id);
        }

        [Authorize(Roles = "Administrator")]
        [HttpPost]
        [Route("generate")]
        public OkResult Generate([FromQuery] CouponSearchRequest request)
        {
            // Bulk generate 5-10 copons
            return Ok();
        }

        [Authorize(Roles = "Client")]
        [HttpPost]
        [Route("use")]
        public OkResult Use([FromQuery] CouponSearchRequest request)
        {
            // Use coupon (client side)
            // Update user wallet object as well as coupon object ?
            return Ok();
        }
    }
}