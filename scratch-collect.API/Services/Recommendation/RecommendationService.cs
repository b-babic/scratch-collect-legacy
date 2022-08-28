using AutoMapper;
using Microsoft.EntityFrameworkCore;
using scratch_collect.API.Database;
using scratch_collect.Model;
using System;
using System.Collections.Generic;
using System.Linq;

namespace scratch_collect.API.Services
{
    public class RecommendationService : IRecommendationService
    {
        private readonly ScratchCollectContext _context;
        private readonly IMapper _mapper;

        public RecommendationService(ScratchCollectContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        private Dictionary<int, List<RatingDTO>> associatedRatings = new Dictionary<int, List<RatingDTO>>();

        private void LoadOtherOffersWithRatings(int itemId)
        {
            List<Offer> collectionWithoutCurrentItem = _context.Offers.Where(o => o.Id != itemId).ToList();
            List<Rating> collectionRatings = new List<Rating>();

            foreach (var item in collectionWithoutCurrentItem)
            {
                collectionRatings = _context
                    .Ratings
                    .Include(x => x.User)
                    .Where(r => r.OfferId == item.Id)
                    .OrderBy(r => r.OfferId)
                    .ToList();

                if (collectionRatings.Count > 0)
                {
                    associatedRatings.Add(item.Id, _mapper.Map<List<RatingDTO>>(collectionRatings));
                }
            }
        }

        private List<RatingDTO> GetCurrentOfferRatings(int itemId)
        {
            List<Rating> ratings = _context
                .Ratings
                .Include(x => x.User)
                .Where(r => r.OfferId == itemId)
                .OrderBy(x => x.UserId)
                .ToList();

            return _mapper.Map<List<RatingDTO>>(ratings);
        }

        private double ComputeSimilarityMatrix(List<RatingDTO> firstSet, List<RatingDTO> secondSet)
        {
            if (firstSet.Count != secondSet.Count) return 0;

            double x = 0, y1 = 0, y2 = 0;
            for (int i = 0; i < firstSet.Count; i++)
            {
                x += firstSet[i].RateCount * secondSet[i].RateCount;
                y1 += firstSet[i].RateCount * firstSet[i].RateCount;
                y2 += secondSet[i].RateCount * secondSet[i].RateCount;
            }

            y1 = Math.Sqrt(y1);
            y2 = Math.Sqrt(y2);
            double y = y1 * y2;

            if (y == 0) return 0;

            return x / y;
        }

        public List<OfferDTO> GetRecommendedItems(int itemId)
        {
            LoadOtherOffersWithRatings(itemId);
            List<RatingDTO> currentOfferRatings = GetCurrentOfferRatings(itemId);

            List<RatingDTO> firstRatingsSet = new List<RatingDTO>();
            List<RatingDTO> secondRatingsSet = new List<RatingDTO>();
            List<OfferDTO> recommendedProducts = new List<OfferDTO>();

            foreach (var associatedRating in associatedRatings)
            {
                foreach (RatingDTO currentRating in currentOfferRatings)
                {
                    if (associatedRating.Value.Where(r => r.User.Id == currentRating.User.Id).Count() > 0)
                    {
                        firstRatingsSet.Add(currentRating);
                        secondRatingsSet.Add(associatedRating.Value.Where(w => w.User.Id == currentRating.User.Id).First());
                    }
                }

                double similarity = ComputeSimilarityMatrix(firstRatingsSet, secondRatingsSet);

                if (similarity > 0.5)
                {
                    var list = _context
                        .Offers
                        .Include(x => x.Category)
                        .Include(x => x.OfferRatings)
                        .AsQueryable()
                        .Where(o => o.Id == associatedRating.Key)
                        .Select(o => new OfferDTO
                        {
                            Id = o.Id,
                            Title = o.Title,
                            Description = o.Description,
                            Quantity = o.Quantity,
                            RequiredPrice = o.RequiredPrice,
                            UpdatedAt = o.UpdatedAt,
                            CreatedAt = o.CreatedAt,
                            Category = _mapper.Map<CategoryDTO>(o.Category),
                            AverageRating = _context
                                    .Ratings
                                    .Where(x => x.OfferId == o.Id)
                                    .Any() ? _context
                                    .Ratings
                                    .Where(x => x.OfferId == o.Id)
                                    .Average(a => a.RateCount) : 0.0
                        })
                        .Where(x => x.AverageRating > 3.0 && x.Quantity > 0)
                        .FirstOrDefault();

                    recommendedProducts.Add(_mapper.Map<OfferDTO>(list));
                }

                firstRatingsSet.Clear();
                secondRatingsSet.Clear();
            }

            return recommendedProducts.Count > 0 ? recommendedProducts
                .Take(5)
                .ToList() : new List<OfferDTO>();
        }
    }
}