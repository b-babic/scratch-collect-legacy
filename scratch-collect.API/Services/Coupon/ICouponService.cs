using System;
using System.Collections.Generic;
using scratch_collect.Model.Coupon;

namespace scratch_collect.API.Services
{
    public interface ICouponService
    {
        ICollection<CouponModel> GetAll(CouponSearchRequest request);
        CouponModel GetById(int id);
        CouponModel Generate(int numberOfItems);

        // TODO: add upsert object here for the patch update ?
        CouponModel Update(int id);
        void Delete(int id);
    }
}