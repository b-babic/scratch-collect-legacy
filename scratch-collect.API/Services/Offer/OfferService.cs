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
        private DataHelper _helper;

        public OfferService(ScratchCollectContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
            _helper = new DataHelper(context);
        }

        public List<OfferDTO> Get(OfferSearchRequest request)
        {
            var query = _context
                .Offers
                .Include(a => a.Category)
                .AsQueryable();

            if (!string.IsNullOrWhiteSpace(request.Query))
            {
                query = query.Where(a => a.Title.Contains(request.Query));
            }

            if (request?.CategoryId != null)
            {
                query = query.Where(x => x.Category.Id == request.CategoryId);
            }

            var list = query
                .Where(x => x.Quantity != 0)
                .Select(x => new OfferDTO
                {
                    Id = x.Id,
                    Title = x.Title,
                    Description = x.Description,
                    CreatedAt = x.CreatedAt,
                    UpdatedAt = x.UpdatedAt,
                    Quantity = x.Quantity,
                    Category = _mapper.Map<CategoryDTO>(x.Category),
                    RequiredPrice = x.RequiredPrice,
                    AverageRating = _helper.CalculateOfferAverageRating(x.Id),
                })
                .OrderByDescending(x => x.UpdatedAt)
                .ToList();

            return _mapper.Map<List<OfferDTO>>(list);
        }

        public OfferDTO GetById(int id)
        {
            var entity = _context
                .Offers
                .Include(c => c.Category)
                .FirstOrDefault(x => x.Id == id);

            var offer = _mapper.Map<OfferDTO>(entity);

            // Recommended items
            var recommended = _context
                .Offers
                .Where(x => x.CategoryId == entity.CategoryId)
                .Select(a => new OfferDTO
                {
                    Id = a.Id,
                    Title = a.Title,
                    Description = a.Description,
                    Quantity = a.Quantity,
                    RequiredPrice = a.RequiredPrice,
                    UpdatedAt = a.UpdatedAt,
                    CreatedAt = a.CreatedAt,
                    Category = _mapper.Map<CategoryDTO>(a.Category),
                    AverageRating = _helper.CalculateOfferAverageRating(a.Id),
                })
                .AsEnumerable()
                .Where(a => a.AverageRating > 3.0)
                .OrderByDescending(a => a.UpdatedAt)
                .Take(3)
                .ToList();

            offer.RecommendedItems = _mapper.Map<List<OfferDTO>>(recommended);

            return offer;
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

            if (!String.IsNullOrEmpty(request?.Query))
            {
                query = query.Where(x => x.Offer.Title.Contains(request.Query));
            }

            // Return only not played offers
            // Default sort by bougt on date
            var list = query
                .Where(a => a.Played == false)
                .OrderByDescending(x => x.BoughtOn)
                .ToList();

            return _mapper.Map<List<UserOfferDTO>>(list);
        }

        public UserOfferDTO Play(UserOfferPlayRequest request)
        {
            var entity = _context.UserOffers
                .Include(a => a.Offer)
                .ThenInclude(c => c.Category)
                .Where(x => x.Id == request.UserOfferId)
                .FirstOrDefault();

            if (entity == null)
                throw new BadRequestException("User offer does not exist!");

            // Set won status
            entity.Played = true;
            entity.PlayedOn = DateTime.Now;
            entity.Won = request.Won;

            _context.UserOffers.Update(entity);
            _context.SaveChanges();

            return _mapper.Map<UserOfferDTO>(entity);
        }
    }
}