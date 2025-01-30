using Microsoft.AspNetCore.Mvc;
using RecuperApp.Common.Helpers;
using RecuperApp.Common.Models;
using RecuperApp.Domain.Models.Requests;
using RecuperApp.Domain.Services.Interfaces;
using RecuperApp.Web.Gateway.Utils;

namespace RecuperApp.Web.Gateway.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LoginController : ControllerBase
    {

        private readonly IEmployeeService _employeeService;
        private readonly IConfiguration _configuration;

        public LoginController(IEmployeeService employeeService, IConfiguration configuration)
        {
            _employeeService = employeeService;
            _configuration = configuration;
        }

        [HttpPost]

        public async Task<HttpResponseModel> ValidateUser(ValidateUserRequest userViewModel)
        {
            var user = await _employeeService.ValidateLogIn(userViewModel);
            string tokenString = JwtConfigurator.GetToken(user, _configuration);
            return new HttpResponseModel(new { user, tokenString });

        }
    }
}
