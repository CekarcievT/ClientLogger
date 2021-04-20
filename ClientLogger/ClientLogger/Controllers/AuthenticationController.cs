using ClientLogger.Business.Interfaces;
using ClientLogger.Business.Models;
using ClientLogger.Infrastructure;
using Microsoft.AspNetCore.Mvc;

namespace ClientLogger.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class AuthenticationController : BaseController
    {
        private readonly IAuthenticationService _authenticationService;

        public AuthenticationController(IAuthenticationService authenticationService)
        {
            _authenticationService = authenticationService;
        }

        [HttpPost("Login")]
        public virtual IActionResult Login(LoginUser user)
        {
            var result = _authenticationService.Login(user);
            return JsonData(result);
        }

        [HttpPost("Logout")]
        [CustomAuthorizationFilter]
        public virtual IActionResult Logout(LoginUser user)
        {
            _authenticationService.Logout(user);
            return JsonData(new { });
        }
    }
}
