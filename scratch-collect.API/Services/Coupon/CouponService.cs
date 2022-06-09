using AutoMapper;
using scratch_collect.API.Database;
using scratch_collect.API.Exceptions;
using scratch_collect.API.Helper;
using scratch_collect.Model;
using scratch_collect.Model.Requests;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

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

        public async Task<bool> Generate(CouponGenerateRequest request)
        {
            var generator = new RandomTokenGenerator();

            for (var i = 0; i < request.CountToGenerate; i++)
            {
                var firstPart = generator.GetUniqueKey(4);
                var secondPart = generator.GetUniqueKey(4);

                var token = String.Format("{0}-{1}", firstPart, secondPart);
                var value = generator.GetRandomCouponValue();

                var coupon = new Coupon
                {
                    Text = token,
                    Value = value,
                    CreatedAt = DateTime.Now
                };

                await _context.Coupons.AddAsync(coupon);
            }

            var saved = await _context.SaveChangesAsync();

            return saved > 0;
        }

        public List<CouponDTO> GetAll(CouponSearchRequest request)
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