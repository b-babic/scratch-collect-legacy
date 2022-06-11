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

        public async Task<List<MerchantVM>> GetAll(string textQuery = null, string countryQuery = null)
        {
            Dictionary<string, string> parameters = new();

            if (!string.IsNullOrEmpty(textQuery))
                parameters["Text"] = textQuery;

            if (!string.IsNullOrEmpty(countryQuery))
                parameters["Country"] = countryQuery;

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

        public async Task<MerchantVM> GetById(string merchantID)
        {
            try
            {
                MerchantDTO merchant = await HttpHelper.GetAsync<MerchantDTO>(_baseUrl + string.Format("/{0}", merchantID));

                // Map to VM
                return _mapper.Map<MerchantVM>(merchant);
            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task<MerchantVM> Insert(MerchantUpsertRequest request)
        {
            try
            {
                var created = await HttpHelper.PostAsync<MerchantDTO, MerchantUpsertRequest>(_baseUrl, request);

                return _mapper.Map<MerchantVM>(created);
            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task<MerchantVM> Update(MerchantUpsertRequest request)
        {
            try
            {
                var updated = await HttpHelper.PutAsync<MerchantVM, MerchantUpsertRequest>(_baseUrl + string.Format("/{0}", request.Id), request);

                return _mapper.Map<MerchantVM>(updated);
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