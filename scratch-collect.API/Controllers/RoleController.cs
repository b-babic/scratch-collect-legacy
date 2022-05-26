using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using scratch_collect.API.Services.Base;
using scratch_collect.Model.Requests;
using scratch_collect.Model.Role;

namespace scratch_collect.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize(Roles = "Administrator")]
    public class RoleController : BaseController<Role, RoleSearchRequest>
    {
        public RoleController(IService<Role, RoleSearchRequest> service) : base(service)
        {
        }
    }
}