using scratch_collect.Model;
using scratch_collect.Model.Requests;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace scratch_collect.Desktop.Services
{
    public class CouponService : ICouponService
    {
        private static string _baseUrl = System.Configuration.ConfigurationManager.AppSettings["BASE_API_URL"] + "coupon";

        public async Task<List<MerchantDTO>> GetAllVouchers(string textQuery)
        {
            Dictionary<string, string> parameters = new Dictionary<string, string>();

            if (!string.IsNullOrEmpty(textQuery))
                parameters["Text"] = textQuery;

            try
            {
                var vouchers = await HttpHelper.GetAsync<List<MerchantDTO>>(_baseUrl + "/all", parameters);

                return vouchers;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task<bool> Generate(int amount)
        {
            var request = new CouponGenerateRequest
            {
                CountToGenerate = amount
            };

            try
            {
                var generated = await HttpHelper.PostAsync<bool, CouponGenerateRequest>(_baseUrl + "/generate", request);

                return generated;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task<bool> DeleteCoupon(int id)
        {
            try
            {
                var response = await HttpHelper.DeleteAsync(_baseUrl + string.Format("/{0}", id));

                return response;
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}