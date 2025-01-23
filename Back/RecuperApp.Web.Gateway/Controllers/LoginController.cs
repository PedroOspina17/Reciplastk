using Microsoft.AspNetCore.Mvc;
using RecuperApp.Common.Helpers;
using RecuperApp.Domain.Models.Requests;
using RecuperApp.Domain.Services;
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

        public async Task<IActionResult> ValidateUser(ValidateUserRequest userViewModel)
        {
            try
            {
                userViewModel.Password = Encrypt.EncryptPassword(userViewModel.Password);
                var user = await _employeeService.ValidateLogIn(userViewModel.UserName, userViewModel.Password);
                if (user == null) return BadRequest(new { Message = "usuario o contraseña Incorrectos" });
                string tokenString = JwtConfigurator.GetToken(user, _configuration);
                return Ok(new { token = tokenString });
            }
            catch (Exception ex)
            {

                return BadRequest(ex.Message);
            }
        }
    }
}
