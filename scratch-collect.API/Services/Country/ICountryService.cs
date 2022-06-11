using scratch_collect.API.Services.Base;
using scratch_collect.Model;
using scratch_collect.Model.Requests;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace scratch_collect.API.Services
{
    public interface ICountryService
    {
        public List<CountryDTO> Get(CountrySearchRequest request);
    }
}