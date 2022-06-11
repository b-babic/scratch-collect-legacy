using scratch_collect.Model;
using scratch_collect.Model.Requests;
using System.Collections.Generic;

namespace scratch_collect.API.Services
{
    public interface IMerchantService
    {
        List<MerchantDTO> GetAll(MerchantSearchRequest request);

        public MerchantDTO GetById(int id);

        public MerchantDTO Insert(MerchantUpsertRequest request);

        public MerchantDTO Update(int id, MerchantUpsertRequest request);
        
        void Delete(int id);
    }
}