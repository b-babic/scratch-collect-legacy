using scratch_collect.Model;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace scratch_collect.Desktop.Services
{
    public interface ICouponService
    {
        public Task<List<CouponDTO>> GetAllVouchers(string textQuery = null);

        public Task<bool> Generate(int amount);

        public Task<bool> DeleteCoupon(int id);
    }
}