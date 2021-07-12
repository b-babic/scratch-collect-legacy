using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using scratch_collect.API.Services;
using scratch_collect.Model.Auth;

namespace scratch_collect.API.Controllers
{
    [ApiController]
    public class AuthController : Controller
    {
        private readonly IAuthenticationService _authService;
        
        public AuthController(IAuthenticationService authService)
        {
            _authService = authService;
        }
        
        [HttpPost]
        [AllowAnonymous]
        [Route("api/[controller]/signin")]
        public IActionResult Signin(SigninRequest request)
        {
            return Ok(_authService.Signin(request));
        }
        
        [HttpPost]
        [AllowAnonymous]
        [Route("api/[controller]/signup")]
        public IActionResult Signup([FromBody] SignupRequest request)
        {
            return Ok(_authService.Signup(request));
        }
    }
}