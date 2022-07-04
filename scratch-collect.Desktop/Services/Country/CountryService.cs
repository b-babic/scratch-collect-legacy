using scratch_collect.Model;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace scratch_collect.Desktop.Services
{
    public class CountryService : ICountryService
    {
        private static string _baseUrl = System.Configuration.ConfigurationManager.AppSettings["BASE_API_URL"] + "country";

        public async Task<List<CountryDTO>> GetAll(string textQuery = null)
        {
            Dictionary<string, string> parameters = new Dictionary<string, string>();

            if (!string.IsNullOrEmpty(textQuery))
                parameters["Text"] = textQuery;

            try
            {
                var countries = await HttpHelper.GetAsync<List<CountryDTO>>(_baseUrl, parameters);

                return countries;
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}