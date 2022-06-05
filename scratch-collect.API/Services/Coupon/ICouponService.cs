using scratch_collect.Model;
using scratch_collect.Model.Requests;
using System.Collections.Generic;

namespace scratch_collect.API.Services
{
    public interface ICouponService
    {
        ICollection<CouponDTO> GetAll(CouponSearchRequest request);

        CouponDTO GetById(int id);

        CouponDTO Generate(int numberOfItems);

        // TODO: add upsert object here for the patch update ?
        CouponDTO Update(int id);

        void Delete(int id);
    }
}