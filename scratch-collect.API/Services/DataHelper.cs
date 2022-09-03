using Microsoft.AspNetCore.Http;
using Newtonsoft.Json.Linq;
using scratch_collect.API.Database;
using System;
using System.Linq;

namespace scratch_collect.API.Services
{
    public class DataHelper
    {
        private readonly ScratchCollectContext _context;

        public DataHelper(ScratchCollectContext context)
        {
            _context = context;
        }

        // Item rating helpers
        public bool CheckIfUserAlreadyRatedItem(int userId, int itemId)
        {
            var alreadyRated = _context
                .Ratings
                .Where(r => r.OfferId == itemId && r.UserId == userId)
                .Any();

            return alreadyRated;
        }

        public bool CheckIfAnyUserRatedItem(int itemId)
        {
            var haveAnyRatings = _context
                .Ratings
                .Where(r => r.OfferId == itemId)
                .Any();

            return haveAnyRatings;
        }

        // Average rating helpers
        private bool HasItemAnyRatings(int id)
        {
            return _context
                    .Ratings
                    .Where(r => r.OfferId == id)
                    .Any();
        }

        private double ItemAverageRating(int id)
        {
            var rawRating = _context
                    .Ratings
                    .Where(r => r.OfferId == id)
                    .Average(r => r.RateCount);

            return Math.Round(rawRating, 2);
        }

        public double CalculateOfferAverageRating(int id)
        {
            const double DEFAULT_RATING = 0.0;

            return HasItemAnyRatings(id)
                ? ItemAverageRating(id)
                : DEFAULT_RATING;
        }
    }
}