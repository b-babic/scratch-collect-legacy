using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using scratch_collect.API.Database;
using scratch_collect.API.Services;
using scratch_collect.API.Services.Base;
using scratch_collect.Model;
using scratch_collect.Model.Requests;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace scratch_collect.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CountryController : Controller
    {
        private readonly ICountryService _countryService;

        public CountryController(ICountryService countryService)
        {
            _countryService = countryService;
        }

        [Authorize(Roles = "Administrator")]
        [HttpGet]
        public ICollection<CountryDTO> Get([FromQuery] CountrySearchRequest request)
        {
            return _countryService.Get(request);
        }
    }
}