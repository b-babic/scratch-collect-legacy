using scratch_collect.Model;
using System.Collections.Generic;

namespace scratch_collect.API.Services
{
    public interface IRecommendationService
    {
        List<OfferDTO> GetRecommendedItems(int itemId);
    }
}