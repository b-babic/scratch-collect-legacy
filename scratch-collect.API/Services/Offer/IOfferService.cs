using scratch_collect.Model;
using scratch_collect.Model.Requests;
using System.Collections.Generic;

namespace scratch_collect.API.Services
{
    public interface IOfferService
    {
        public List<OfferDTO> Get(OfferSearchRequest query);

        public OfferDTO GetById(int id);

        public OfferDTO Insert(OfferUpsertRequest request);

        public OfferDTO Update(int id, OfferUpsertRequest request);

        public void Delete(int id);

        // User Offers
        public UserOfferDTO BuyOffer(UserOfferUpsertRequest request);

        public UserOfferDTO ArchiveOffer(UserOfferUpsertRequest request);

        public List<UserOfferDTO> GetUserOffers(UsserOfferSearchRequest request);

        public UserOfferDTO Play(UserOfferPlayRequest request);
    }
}