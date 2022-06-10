using scratch_collect.Model.Desktop;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace scratch_collect.Desktop.Services
{
    public interface IMerchantService
    {
        public Task<List<MerchantVM>> GetAll(string textQuery = null, string countryId = null);

        public Task<bool> Delete(int id);
    }
}