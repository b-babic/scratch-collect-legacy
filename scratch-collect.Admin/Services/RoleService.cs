using scratch_collect.Model;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace scratch_collect.Admin.Services
{
    public class RoleService
    {
        private static string _baseUrl = System.Configuration.ConfigurationManager.AppSettings["BASE_API_URL"] + "role";

        public static async Task<List<RoleDTO>> GetAllRoles()
        {
            // get all roles
            try
            {
                var roles = await BaseService.GetAsync<List<RoleDTO>>(_baseUrl + "/all");

                return roles;
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}