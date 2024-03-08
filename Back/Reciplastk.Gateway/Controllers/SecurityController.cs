using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Reciplastk.Gateway.Models;
using Reciplastk.Gateway.Services;

namespace Reciplastk.Gateway.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SecurityController : ControllerBase
    {
        private readonly SecurityService securityService;

        public SecurityController(SecurityService securityService)
        {
            this.securityService = securityService;
        }

        [HttpPost("Login")]
        public HttpResponseModel Login(LoginModel loginModel) {
            return securityService.Login(loginModel);
        }
    }
}
