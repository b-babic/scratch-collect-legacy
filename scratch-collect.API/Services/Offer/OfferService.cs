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
    public class OfferService : IOfferService
    {
        private readonly ScratchCollectContext _context;
        private readonly IMapper _mapper;

        public OfferService(ScratchCollectContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public List<OfferDTO> Get(OfferSearchRequest request)
        {
            var query = _context.Offers.Include(a => a.Category).AsQueryable();

            if (request?.CategoryId != null)
            {
                query = query.Where(x => x.Category.Id == request.CategoryId);
            }

            // Default sort
            var list = query
                .OrderByDescending(x => x.UpdatedAt)
                .ToList();

            return _mapper.Map<List<OfferDTO>>(list);
        }

        public OfferDTO GetById(int id)
        {
            var entity =
                _context.Set<Offer>()
                .Include(c => c.Category)
                .FirstOrDefault(x => x.Id == id);

            return _mapper.Map<OfferDTO>(entity);
        }

        public OfferDTO Insert(OfferUpsertRequest request)
        {
            var entity = _mapper.Map<Offer>(request);

            if (entity.CategoryId == 0) throw new BadRequestException("Offer must belong to some category !");

            // optional fields
            entity.CreatedAt = DateTime.Now;
            entity.UpdatedAt = DateTime.Now;

            // check if merchant already exist ?
            var offerExists = _context.Offers.Any(x => x.Title == request.Title);

            if (offerExists)
                throw new BadRequestException("Offer with provided title already exist in the system !");

            _context.Offers.Add(entity);
            _context.SaveChanges();

            _context.SaveChanges();

            var result = _context.Offers.Include(a => a.Category).FirstOrDefault(x => x.Id == entity.Id);

            return _mapper.Map<OfferDTO>(result);
        }

        public OfferDTO Update(int id, OfferUpsertRequest request)
        {
            var entity = _context.Offers
                .Include(a => a.Category)
                .FirstOrDefault(x => x.Id == request.Id);

            if (entity == null)
                throw new BadRequestException("Offer does not exist !");

            if (request.CreatedAt == null) request.CreatedAt = entity.CreatedAt;
            if (request.UpdatedAt == null) request.UpdatedAt = entity.UpdatedAt;

            _context.Offers.Attach(entity);
            _context.Offers.Update(entity);
            _mapper.Map(request, entity);

            _context.SaveChanges();

            return _mapper.Map<OfferDTO>(entity);
        }

        public void Delete(int id)
        {
            var entity = _context.Offers.Find(id);

            if (entity == null)
            {
                throw new BadRequestException("There is no offer with provided id !");
            }

            _context.Offers.Remove(entity);
            _context.SaveChanges();
        }
    }
}