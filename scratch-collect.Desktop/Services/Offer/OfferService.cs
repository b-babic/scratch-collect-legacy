using AutoMapper;
using scratch_collect.Model;
using scratch_collect.Model.Requests;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace scratch_collect.Desktop.Services
{
    public class OfferService : IOfferService
    {
        private static string _baseUrl = System.Configuration.ConfigurationManager.AppSettings["BASE_API_URL"] + "offer";

        private readonly IMapper _mapper;

        public OfferService(IMapper mapper)
        {
            _mapper = mapper;
        }

        public async Task<List<OfferDTO>> GetAll(string? categoryId = null)
        {
            Dictionary<string, string> parameters = new Dictionary<string, string>();

            if (!string.IsNullOrEmpty(categoryId))
                parameters["CategoryId"] = categoryId;

            try
            {
                var offers = await HttpHelper.GetAsync<List<OfferDTO>>(_baseUrl, parameters);

                return _mapper.Map<List<OfferDTO>>(offers);
            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task<OfferDTO> GetById(int id)
        {
            try
            {
                OfferDTO offer = await HttpHelper.GetAsync<OfferDTO>(_baseUrl + string.Format("/{0}", id));

                // Map to VM
                return _mapper.Map<OfferDTO>(offer);
            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task<OfferDTO> Insert(OfferUpsertRequest request)
        {
            try
            {
                var created = await HttpHelper.PostAsync<OfferDTO, OfferUpsertRequest>(_baseUrl, request);

                return _mapper.Map<OfferDTO>(created);
            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task<OfferDTO> Update(OfferUpsertRequest request)
        {
            try
            {
                var updated = await HttpHelper.PutAsync<OfferDTO, OfferUpsertRequest>(_baseUrl + string.Format("/{0}", request.Id), request);

                return _mapper.Map<OfferDTO>(updated);
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