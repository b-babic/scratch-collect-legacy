using AutoMapper;
using Microsoft.EntityFrameworkCore;
using scratch_collect.API.Database;
using scratch_collect.API.Exceptions;
using scratch_collect.Model;
using scratch_collect.Model.Requests;
using System;
using System.Collections.Generic;
using System.Linq;

namespace scratch_collect.API.Services
{
    public class MerchantService : IMerchantService
    {
        private readonly ScratchCollectContext _context;
        private readonly IMapper _mapper;

        public MerchantService(ScratchCollectContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public List<MerchantDTO> GetAll(MerchantSearchRequest request)
        {
            var query = _context.Merchants.Include(a => a.Country).AsQueryable();

            if (!string.IsNullOrWhiteSpace(request?.Text))
            {
                query = query.Where(x => x.Name.StartsWith(request.Text));
            }

            if (!string.IsNullOrWhiteSpace(request?.Country))
            {
                query = query.Where(x => x.Country.Name.Contains(request.Country));
            }

            var list = query.ToList();

            return _mapper.Map<List<MerchantDTO>>(list);
        }

        public void Delete(int id)
        {
            var entity = _context.Merchants.Find(id);

            if (entity == null)
            {
                throw new BadRequestException("There is no merchant with provided id !");
            }

            _context.Merchants.Remove(entity);
            _context.SaveChanges();
        }
    }
}