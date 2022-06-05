using scratch_collect.Model;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace scratch_collect.Desktop.Services
{
    public interface IRoleService
    {
        public Task<List<RoleDTO>> GetAllRoles();
    }
}