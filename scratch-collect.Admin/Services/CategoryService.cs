using scratch_collect.Model;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace scratch_collect.Admin.Services
{
    public class CategoryService
    {
        private static string _baseUrl = System.Configuration.ConfigurationManager.AppSettings["BASE_API_URL"] + "category";

        public static async Task<List<CategoryDTO>> Get()
        {
            try
            {
                var categories = await BaseService.GetAsync<List<CategoryDTO>>(_baseUrl);

                return categories;
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}