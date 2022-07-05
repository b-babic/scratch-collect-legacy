using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using scratch_collect.API.Services;
using scratch_collect.Model.Report;
using System.Collections.Generic;

namespace scratch_collect.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize(Roles = "Administrator")]
    public class ReportController : ControllerBase
    {
        private IReportService _reportService;

        public ReportController(IReportService reportService)
        {
            _reportService = reportService;
        }

        [HttpPost]
        [Route("success-offers")]
        public List<SuccessOffer> GetSuccessOffers([FromBody] SuccessOffersRequest request)
        {
            return _reportService.SuccessOffers(request);
        }

        [HttpGet]
        [Route("active-users")]
        public List<ActiveUser> GetActiveUsers()
        {
            return _reportService.ActiveUsers();
        }

        [HttpPost]
        [Route("offer-info")]
        public List<OfferInfo> GetOfferInfo([FromBody] OfferInfoRequest request)
        {
            return _reportService.OfferInfo(request);
        }
    }
}