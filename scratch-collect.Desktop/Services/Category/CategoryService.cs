using scratch_collect.Model;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace scratch_collect.Desktop.Services
{
    public class CategoryService : ICategoryService
    {
        private static string _baseUrl = System.Configuration.ConfigurationManager.AppSettings["BASE_API_URL"] + "category";

        public async Task<List<CategoryDTO>> Get()
        {
            try
            {
                var categories = await HttpHelper.GetAsync<List<CategoryDTO>>(_baseUrl);

                return categories;
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}