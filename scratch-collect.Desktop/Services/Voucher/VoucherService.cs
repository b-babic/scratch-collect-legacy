using scratch_collect.Model;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace scratch_collect.Desktop.Services
{
    public class VoucherService : IVoucherService
    {
        private static string _baseUrl = System.Configuration.ConfigurationManager.AppSettings["BASE_API_URL"] + "voucher";

        public async Task<List<CouponDTO>> GetAllVouchers()
        {
            try
            {
                var vouchers = await HttpHelper.GetAsync<List<CouponDTO>>(_baseUrl + "/all");

                return vouchers;
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}