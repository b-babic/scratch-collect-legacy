using AutoMapper;
using scratch_collect.Model;
using scratch_collect.Model.Desktop;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace scratch_collect.Desktop.Services
{
    public class MerchantService : IMerchantService
    {
        private static string _baseUrl = System.Configuration.ConfigurationManager.AppSettings["BASE_API_URL"] + "merchant";
        private readonly IMapper _mapper;

        public MerchantService(IMapper mapper)
        {
            _mapper = mapper;
        }

        public async Task<List<MerchantVM>> GetAll(string textQuery = null, string countryId = null)
        {
            Dictionary<string, string> parameters = new();

            if (!string.IsNullOrEmpty(textQuery))
                parameters["Text"] = textQuery;

            if (!string.IsNullOrEmpty(countryId))
                parameters["CountryId"] = countryId;

            try
            {
                var merchants = await HttpHelper.GetAsync<List<MerchantDTO>>(_baseUrl, parameters);

                return _mapper.Map<List<MerchantVM>>(merchants);
            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task<bool> Delete(int id)
        {
            try
            {
                var response = await HttpHelper.DeleteAsync(_baseUrl + string.Format("/{0}", id));

                return response;
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}