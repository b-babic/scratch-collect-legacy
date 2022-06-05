using scratch_collect.Model;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace scratch_collect.Desktop.Services
{
    public class RoleService : IRoleService
    {
        private static string _baseUrl = System.Configuration.ConfigurationManager.AppSettings["BASE_API_URL"] + "role";

        public async Task<List<RoleDTO>> GetAllRoles()
        {
            // get all roles
            try
            {
                var roles = await HttpHelper.GetAsync<List<RoleDTO>>(_baseUrl + "/all");

                return roles;
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}