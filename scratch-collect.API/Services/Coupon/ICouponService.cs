using scratch_collect.Model;
using scratch_collect.Model.Requests;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace scratch_collect.API.Services
{
    public interface ICouponService
    {
        List<CouponDTO> GetAll(CouponSearchRequest request);

        CouponDTO GetById(int id);

        Task<bool> Generate(CouponGenerateRequest request);

        CouponDTO Update(int id);

        void Delete(int id);
    }
}