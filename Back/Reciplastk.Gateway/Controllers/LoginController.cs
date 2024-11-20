using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Reciplastk.Gateway.Common;
using Reciplastk.Gateway.Models;
using Reciplastk.Gateway.Services;

namespace Reciplastk.Gateway.Controllers
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

        public async Task<IActionResult> ValidateUser(UserViewModel userViewModel)
        {
            try
            {
                userViewModel.Password = Encrypt.EncryptPassword(userViewModel.Password);
                var user = await _employeeService.ValidateUser(userViewModel.UserName, userViewModel.Password);
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
