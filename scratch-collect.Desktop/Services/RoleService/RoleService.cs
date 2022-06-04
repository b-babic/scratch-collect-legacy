using scratch_collect.Model.Role;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace scratch_collect.Desktop.Services
{
    public class RoleService : IRoleService
    {
        private static string _baseUrl = System.Configuration.ConfigurationManager.AppSettings["BASE_API_URL"] + "role";

        public async Task<List<Role>> GetAllRoles()
        {
            // get all roles
            try
            {
                var roles = await HttpHelper.GetAsync<List<Role>>(_baseUrl);

                return roles;
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}