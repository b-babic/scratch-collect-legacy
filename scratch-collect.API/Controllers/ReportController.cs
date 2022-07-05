using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using scratch_collect.API.Services;
using scratch_collect.Model;
using scratch_collect.Model.Report;
using scratch_collect.Model.Requests;
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
        public List<SuccessOffer> Get([FromBody] SuccessOffersRequest request)
        {
            return _reportService.SuccessOffers(request);
        }
    }
}