using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using scratch_collect.API.Services;
using scratch_collect.Model;
using scratch_collect.Model.Requests;
using System.Collections.Generic;

namespace scratch_collect.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize(Roles = "Administrator")]
    public class RoleController : ControllerBase
    {
        private IRoleService _roleService;

        public RoleController(IRoleService roleService)
        {
            _roleService = roleService;
        }

        [HttpGet]
        [Route("all")]
        public List<RoleDTO> Get([FromQuery] RoleSearchRequest request)
        {
            return _roleService.Get(request);
        }

        [HttpGet("{id:int}")]
        public RoleDTO GetById(int id)
        {
            return _roleService.GetById(id);
        }
    }
}