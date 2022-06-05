using scratch_collect.Model;
using scratch_collect.Model.Requests;
using System.Collections.Generic;

namespace scratch_collect.API.Services
{
    public interface IRoleService
    {
        public List<RoleDTO> Get(RoleSearchRequest search);

        public RoleDTO GetById(int id);
    }
}