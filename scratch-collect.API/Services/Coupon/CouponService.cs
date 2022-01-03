using AutoMapper;
using scratch_collect.API.Database;
using scratch_collect.Model.Coupon;
using System;
using System.Collections.Generic;
using System.Linq;

namespace scratch_collect.API.Services.Coupon
{
    public class CouponService : ICouponService
    {
        private readonly ScratchCollectContext _context;
        private readonly IMapper _mapper;

        public CouponService(ScratchCollectContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public void Delete(int id)
        {
            throw new NotImplementedException();
        }

        public CouponModel Generate(int numberOfItems)
        {
            throw new NotImplementedException();
        }

        public ICollection<CouponModel> GetAll(CouponSearchRequest request)
        {
            var query = _context.Coupons.AsQueryable();

            if (!string.IsNullOrWhiteSpace(request?.Text))
            {
                query = query.Where(x => x.Text.StartsWith(request.Text));
            }

            var list = query.ToList();

            return _mapper.Map<List<CouponModel>>(list);
        }

        public CouponModel GetById(int id)
        {
            throw new NotImplementedException();
        }

        public CouponModel Update(int id)
        {
            throw new NotImplementedException();
        }
    }
}
