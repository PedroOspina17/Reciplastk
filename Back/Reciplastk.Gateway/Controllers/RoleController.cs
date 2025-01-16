using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Reciplastk.Gateway.DataAccess;
using Reciplastk.Gateway.Models;
using Reciplastk.Gateway.Services;

namespace Reciplastk.Gateway.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RoleController : ControllerBase
    {
        private readonly IRoleService roleService;
        private readonly IMapper mapper;

        public RoleController(IRoleService _roleService, IMapper _mapper)
        {
            roleService = _roleService;
            mapper = _mapper;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllRole()
        {
            try
            {
                var roles = await roleService.GetAllRoles();
                if (roles == null || roles.Count == 0)
                {
                    return Ok(new { message = "not roles created" });
                }

                return Ok(roles);
            }
            catch (Exception ex)
            {

                return BadRequest(ex.Message);
            }
        }


        [HttpGet("{id}")]
        public async Task<IActionResult> GetRoleById(int id)
        {
            try
            {
                var role = await roleService.GetRoleById(id);
                if (role == null)
                {
                    return NotFound(new { message = "Not Data found" });
                }

                return Ok(role);
            }
            catch (Exception ex)
            {

                return BadRequest(ex.Message);
            }
        }


        [HttpPost]
        public async Task<IActionResult> AddRole([FromBody] RoleViewModel roleViewModel)
        {
            try
            {
                var existRole = await roleService.GetRoleByName(roleViewModel.Name);
                if (existRole == null)
                {
                    var role = mapper.Map<Role>(roleViewModel);
                    //rol.IsActive = true;
                    await roleService.AddRole(role);
                    return Ok(new { message = "role created successfully" });
                }

                return Ok(new { message = "The role already exist" });
            }
            catch (Exception ex)
            {

                return BadRequest(ex.Message);
            }
        }


        [HttpPut]
        public async Task<IActionResult> UpdateRol([FromBody] RoleViewModel roleViewModel)
        {
            try
            {
                var existRole = await roleService.GetRoleById(roleViewModel.Roleid);
                if (existRole != null)
                {
                    mapper.Map(roleViewModel, existRole);
                    await roleService.UpdateRole(existRole);
                    return Ok(new { message = "rol edited successfully" });
                }

                return Ok(new { message = "The rol not exist" });
            }
            catch (Exception ex)
            {

                return BadRequest(ex.Message);
            }
        }


        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteRol(int id)
        {
            try
            {
                var existRole = await roleService.GetRoleById(id);
                if (existRole != null)
                {
                    await roleService.DeleteRole(existRole);
                    return Ok(new { message = "rol deleted successfully" });
                }

                return Ok(new { message = "The rol not exist" });
            }
            catch (Exception ex)
            {

                return BadRequest(ex.Message);
            }
        }
    }
}
