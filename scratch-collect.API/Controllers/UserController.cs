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
    public class UserController : ControllerBase
    {
        private readonly IUserService _userService;
        private readonly IOfferService _offerService;

        public UserController(IUserService userService, IOfferService offerService)
        {
            _userService = userService;
            _offerService = offerService;
        }

        [Authorize(Roles = "Administrator")]
        [HttpGet]
        [Route("all")]
        public List<UserDTO> Get([FromQuery] UserSearchRequest request)
        {
            return _userService.Get(request);
        }

        [Authorize(Roles = "Administrator, Client")]
        [HttpGet("{id:int}")]
        public UserDTO GetById(int id)
        {
            return _userService.GetById(id);
        }

        [Authorize(Roles = "Administrator")]
        [HttpPost]
        public UserDTO Insert(UserUpsertRequest request)
        {
            return _userService.Insert(request);
        }

        [AllowAnonymous]
        [HttpPut("{id:int}")]
        public UserDTO Update(int id, UserUpsertRequest request)
        {
            return _userService.Update(id, request);
        }

        [AllowAnonymous]
        [HttpPatch("profile/{id:int}")]
        public UserDTO EditProfile(int id, EditProfileRequest request)
        {
            return _userService.EditProfile(id, request);
        }

        [AllowAnonymous]
        [HttpPatch("profile/{id:int}/password")]
        public UserDTO EditPassword(int id, EditPasswordRequest request) {
            return _userService.EditPassword(id, request);
        }

        [AllowAnonymous]
        [HttpGet("profile/{id:int}")]
        public UserDTO Profile(int id)
        {
            return _userService.GetById(id);
        }

        [Authorize(Roles = "Administrator")]
        [HttpDelete("{id:int}")]
        public void Delete(int id)
        {
            _userService.Delete(id);
        }

        // User offers
        [Authorize(Roles = "Administrator, Client")]
        [HttpPost("{id:int}/offers")]
        public List<UserOfferDTO> Offers([FromBody] UsserOfferSearchRequest request)
        {
            return _offerService.GetUserOffers(request);
        }

        // User coupons
        [Authorize(Roles = "Administrator, Client")]
        [HttpGet("{id:int}/coupons")]
        public List<CouponDTO> Coupons(int id)
        {
            return _userService.GetUsersCoupons(id);
        }

        // User won items
        [Authorize(Roles = "Administrator, Client")]
        [HttpGet("{id:int}/won")]
        public List<UserOfferDTO> WonItems([FromBody] UsserOfferSearchRequest request)
        {
            return _userService.UserWonItems(request);
        }

        [Authorize(Roles = "Administrator")]
        [HttpGet("won/all")]
        public List<UserOfferDTO> AllWonItems([FromQuery] UsserOfferSearchRequest request)
        {
            return _userService.AllWonItems(request);
        }
    }
}