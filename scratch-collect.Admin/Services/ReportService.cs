using scratch_collect.Model.Report;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace scratch_collect.Admin.Services
{
    public class ReportService
    {
        private static string _baseUrl = System.Configuration.ConfigurationManager.AppSettings["BASE_API_URL"] + "report";

        public static async Task<List<SuccessOffer>> SuccessOffers(SuccessOffersRequest request)
        {
            try
            {
                var offers = await BaseService.PostAsync<List<SuccessOffer>, SuccessOffersRequest>(_baseUrl + "/success-offers", request);

                return offers;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public static async Task<List<ActiveUser>> ActiveUsers()
        {
            try
            {
                var users = await BaseService.GetAsync<List<ActiveUser>>(_baseUrl + "/active-users");

                return users;
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}