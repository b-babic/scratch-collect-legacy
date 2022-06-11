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

        public MerchantDTO GetById(int id)
        {
            var entity = _context.Merchants
                .Include(x => x.Country)
                .SingleOrDefault(x => x.Id == id);

            return _mapper.Map<MerchantDTO>(entity);
        }

        public MerchantDTO Insert(MerchantUpsertRequest request)
        {
            var entity = _mapper.Map<Merchant>(request);

            // optional fields
            entity.CreatedAt = DateTime.Now;

            // check if merchant already exist ?
            var merchantExists = _context.Merchants.Any(x => x.Name == request.Name);

            if (merchantExists)
                throw new BadRequestException("Merchant with provided name already exist in the system !");

            _context.Merchants.Add(entity);
            _context.SaveChanges();

            _context.SaveChanges();

            var result = _context.Merchants.Include(a => a.Country).FirstOrDefault(x => x.Id == entity.Id);

            return _mapper.Map<MerchantDTO>(result);
        }

        public MerchantDTO Update(int id, MerchantUpsertRequest request)
        {
            var entity = _context.Merchants.Find(id);

            if (entity == null)
                throw new BadRequestException("Merchant does not exist !");

            if (request.CreatedAt == null) request.CreatedAt = entity.CreatedAt;

            _context.Merchants.Attach(entity);
            _context.Merchants.Update(entity);
            _mapper.Map(request, entity);

            _context.SaveChanges();

            return _mapper.Map<MerchantDTO>(entity);
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