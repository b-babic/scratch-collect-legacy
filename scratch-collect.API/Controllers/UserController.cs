using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using scratch_collect.API.Services;
using scratch_collect.Model.User;
using System.Collections.Generic;

namespace scratch_collect.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUserService _userService;

        public UserController(IUserService service)
        {
            _userService = service;
        }

        [Authorize(Roles = "Administrator")]
        [HttpGet]
        [Route("all")]
        public List<User> Get([FromQuery] UserSearchRequest request)
        {
            return _userService.Get(request);
        }

        [Authorize(Roles = "Administrator, Client")]
        [HttpGet("{id:int}")]
        public User GetById(int id)
        {
            return _userService.GetById(id);
        }

        [Authorize(Roles = "Administrator")]
        [HttpPost]
        public User Insert(UserUpsertRequest request)
        {
            return _userService.Insert(request);
        }

        [AllowAnonymous]
        [HttpPut("{id:int}")]
        public User Update(int id, UserUpsertRequest request)
        {
            return _userService.Update(id, request);
        }

        [AllowAnonymous]
        [HttpPut("profile/{id:int}")]
        public User EditProfile(int id, UserUpsertRequest request)
        {
            return _userService.Update(id, request);
        }

        [AllowAnonymous]
        [HttpGet("profile/{id:int}")]
        public User Profile(int id)
        {
            return _userService.GetById(id);
        }

        [Authorize(Roles = "Administrator")]
        [HttpDelete("{id:int}")]
        public void Delete(int id)
        {
            _userService.Delete(id);
        }
    }
}