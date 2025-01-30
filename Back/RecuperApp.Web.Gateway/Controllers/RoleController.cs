using Microsoft.AspNetCore.Mvc;
using RecuperApp.Common.Models;
using RecuperApp.Domain.Models.ViewModels;
using RecuperApp.Domain.Services.Interfaces;

namespace RecuperApp.Web.Gateway.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RoleController : ControllerBase
    {
        private readonly IRoleService roleService;

        public RoleController(IRoleService _roleService)
        {
            roleService = _roleService;
        }

        [HttpGet("GetAll")]
        public async Task<HttpResponseModel> GetAll()
        {

            var roles = await roleService.GetAll();
            return new HttpResponseModel(roles);

        }


        [HttpGet("GetById")]
        public async Task<HttpResponseModel> GetById(int id)
        {
            var role = await roleService.GetById(id);
            return new HttpResponseModel(role);

        }


        [HttpPost("Create")]
        public async Task<HttpResponseModel> Create([FromBody] RoleViewModel roleViewModel)
        {

            var role = await roleService.Create(roleViewModel);
            return new HttpResponseModel(role,$"Se creó el rol {role.Name} exitosamente con id #{role.Id}");
        }


        [HttpPut("Update")]
        public async Task<HttpResponseModel> Update([FromBody] RoleViewModel roleViewModel)
        {

            var role = await roleService.Update(roleViewModel);
            return new HttpResponseModel(role, $"Se actualizó el rol {role.Name} exitosamente");

        }


        [HttpDelete("Delete")]
        public async Task<HttpResponseModel> Delete(int id)
        {
            var role = await roleService.Delete(id);
            return new HttpResponseModel($"Se eliminó el rol {role.Name} exitosamente");

        }
    }
}
