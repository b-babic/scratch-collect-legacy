using AutoMapper;
using scratch_collect.API.Database;
using scratch_collect.API.Exceptions;
using scratch_collect.Model;
using scratch_collect.Model.Requests;
using System;
using System.Collections.Generic;
using System.Linq;

namespace scratch_collect.API.Services
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

        public CouponDTO Generate(int numberOfItems)
        {
            throw new NotImplementedException();
        }

        public ICollection<CouponDTO> GetAll(CouponSearchRequest request)
        {
            var query = _context.Coupons.AsQueryable();

            if (!string.IsNullOrWhiteSpace(request?.Text))
            {
                query = query.Where(x => x.Text.StartsWith(request.Text));
            }

            var list = query.ToList();

            return _mapper.Map<List<CouponDTO>>(list);
        }

        public CouponDTO GetById(int id)
        {
            throw new NotImplementedException();
        }

        public CouponDTO Update(int id)
        {
            throw new NotImplementedException();
        }

        public void Delete(int id)
        {
            var entity = _context.Coupons.Find(id);

            if (entity == null)
            {
                throw new BadRequestException("There is no coupon with provided text !");
            }

            _context.Coupons.Remove(entity);
            _context.SaveChanges();
        }
    }
}