using scratch_collect.Model.Report;
using System.Collections.Generic;

namespace scratch_collect.API.Services
{
    public interface IReportService
    {
        List<SuccessOffer> SuccessOffers(SuccessOffersRequest request);

        List<ActiveUser> ActiveUsers();

        List<OfferInfo> OfferInfo(OfferInfoRequest request);
    }
}