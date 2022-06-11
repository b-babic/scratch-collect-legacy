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
    public class MerchantController : Controller
    {
        private readonly IMerchantService _merchantService;

        public MerchantController(IMerchantService merchantService)
        {
            _merchantService = merchantService;
        }

        [Authorize(Roles = "Administrator")]
        [HttpGet]
        public List<MerchantDTO> Get([FromQuery] MerchantSearchRequest request)
        {
            return _merchantService.GetAll(request);
        }

        [Authorize(Roles = "Administrator, Client")]
        [HttpGet("{id:int}")]
        public MerchantDTO GetById(int id)
        {
            return _merchantService.GetById(id);
        }

        [Authorize(Roles = "Administrator")]
        [HttpPost]
        public MerchantDTO Insert(MerchantUpsertRequest request)
        {
            return _merchantService.Insert(request);
        }

        [AllowAnonymous]
        [HttpPut("{id:int}")]
        public MerchantDTO Update(int id, MerchantUpsertRequest request)
        {
            return _merchantService.Update(id, request);
        }

        [Authorize(Roles = "Administrator")]
        [HttpDelete("{id:int}")]
        public void Delete(int id)
        {
            _merchantService.Delete(id);
        }
    }
}