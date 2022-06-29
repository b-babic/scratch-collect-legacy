using scratch_collect.Model;
using scratch_collect.Model.Requests;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace scratch_collect.API.Services
{
    public interface ICouponService
    {
        List<CouponDTO> GetAll(CouponSearchRequest request);

        MerchantDTO GetById(int id);

        Task<bool> Generate(CouponGenerateRequest request);

        MerchantDTO Update(int id);

        void Delete(int id);

        // Use Coupon
        public WalletDTO Use (CouponUseRequest request);
    }
}