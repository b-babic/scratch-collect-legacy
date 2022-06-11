using scratch_collect.Model;
using scratch_collect.Model.Desktop;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace scratch_collect.Desktop.Services
{
    public interface IMerchantService
    {
        public Task<List<MerchantVM>> GetAll(string textQuery = null, string countryQuery = null);

        public Task<MerchantVM> GetById(string merchantID);

        public Task<MerchantVM> Insert(MerchantUpsertRequest request);

        public Task<MerchantVM> Update(MerchantUpsertRequest request);

        public Task<bool> Delete(int id);
    }
}