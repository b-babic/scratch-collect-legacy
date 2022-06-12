using scratch_collect.Model;
using scratch_collect.Model.Requests;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace scratch_collect.Desktop.Services
{
    public interface IOfferService
    {
        public Task<List<OfferDTO>> GetAll(string? categoryId = null);

        public Task<OfferDTO> GetById(int id);

        public Task<OfferDTO> Insert(OfferUpsertRequest request);

        public Task<OfferDTO> Update(OfferUpsertRequest request);

        public Task<bool> Delete(int id);
    }
}