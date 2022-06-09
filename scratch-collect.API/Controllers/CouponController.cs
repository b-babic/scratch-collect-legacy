using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using scratch_collect.API.Services;
using scratch_collect.Model;
using scratch_collect.Model.Requests;
using System.Collections.Generic;
using System.Threading.Tasks;

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

        [Authorize(Roles = "Client")]
        [HttpPost]
        [Route("use")]
        public OkResult Use([FromQuery] CouponGenerateRequest request)
        {
            // Use coupon (client side)
            // Update user wallet object as well as coupon object ?
            return Ok();
        }
    }
}