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

        // User offers
        public UserOfferDTO BuyOffer(UserOfferUpsertRequest request)
        {
            // validate if user has money
            var user = _context.Users
                .Include(w => w.Wallet)
                .FirstOrDefault(a => a.Id == request.UserId);
            var offer = _context.Offers.Find(request.OfferId);

            // If by any chance request is not constructed properly
            if (user == null || offer == null)
                throw new BadRequestException("Either user or offer not found !");

            // If offer is expired
            if (offer.Quantity == 0)
                throw new BadRequestException("This offer expired !");

            // If user have enough money to buy
            var enoughMoney = user.Wallet.Balance >= offer.RequiredPrice;

            if (!enoughMoney)
                throw new BadRequestException("You don't have enough money to buy this item !");

            // Add offer to user offers
            var model = new UserOffer
            {
                Played = request?.Played ?? false,
                BoughtOn = DateTime.Now,
                UserId = request.UserId,
                OfferId = request.OfferId
            };

            _context.UserOffers.Add(model);

            var bought = _mapper.Map<UserOfferDTO>(model);

            // Decrement offer quantity and update user wallet balance
            if (bought != null)
            {
                // Remove user money
                user.Wallet.Balance -= offer.RequiredPrice;

                // Remove offer quantity
                offer.Quantity -= 1;

                _context.Users.Update(user);
                _context.Offers.Update(offer);

                _context.SaveChanges();
            }

            // Return new offer
            return bought;
        }

        public UserOfferDTO ArchiveOffer(UserOfferUpsertRequest request)
        {
            var offer = _context.UserOffers.Find(request.OfferId);

            if (offer == null)
                throw new BadRequestException("Offer does not exist !");

            // After successfull scratch / play, we can archive currently played offer and hide it from the original list
            offer.Played = true;

            _context.UserOffers.Update(offer);
            _context.SaveChanges();

            return _mapper.Map<UserOfferDTO>(offer);
        }

        public List<UserOfferDTO> GetUserOffers(UsserOfferSearchRequest request)
        {
            var query = _context.UserOffers
                .Include(a => a.Offer)
                .ThenInclude(c => c.Category)
                .AsQueryable();

            if (request?.UserId == null)
                throw new BadRequestException("You have to pass specific user ID !");

            if (request?.UserId != null)
            {
                query = query.Where(x => x.UserId == request.UserId);
            }

            if (request?.CategoryId != null)
            {
                query = query.Where(x => x.Offer.Category.Id == request.CategoryId);
            }

            // Return only not played offers
            // Default sort by bougt on date
            var list = query
                .Where(a => a.Played == false)
                .OrderByDescending(x => x.BoughtOn)
                .ToList();

            return _mapper.Map<List<UserOfferDTO>>(list);
        }
    }
}