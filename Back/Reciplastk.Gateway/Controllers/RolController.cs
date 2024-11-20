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
    public class RolController : ControllerBase
    {
        private readonly IRolService rolService;
        private readonly IMapper mapper;

        public RolController(IRolService _rolService, IMapper _mapper)
        {
            rolService = _rolService;
            mapper = _mapper;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllRol()
        {
            try
            {
                var rols = await rolService.GetAllRol();
                if (rols == null || rols.Count == 0)
                {
                    return Ok(new { message = "not rols created" });
                }

                return Ok(rols);
            }
            catch (Exception ex)
            {

                return BadRequest(ex.Message);
            }
        }


        [HttpGet("{id}")]
        public async Task<IActionResult> GetRolById(int id)
        {
            try
            {
                var rol = await rolService.GetRolById(id);
                if (rol == null)
                {
                    return NotFound(new { message = "Not Data found" });
                }

                return Ok(rol);
            }
            catch (Exception ex)
            {

                return BadRequest(ex.Message);
            }
        }


        [HttpPost]
        public async Task<IActionResult> AddRol([FromBody] RolViewModel rolViewModel)
        {
            try
            {
                var existRol = await rolService.GetRolByName(rolViewModel.Name);
                if (existRol == null)
                {
                    var rol = mapper.Map<Rol>(rolViewModel);
                    //rol.IsActive = true;
                    await rolService.AddRol(rol);
                    return Ok(new { message = "rol created successfully" });
                }

                return Ok(new { message = "The rol already exist" });
            }
            catch (Exception ex)
            {

                return BadRequest(ex.Message);
            }
        }


        [HttpPut]
        public async Task<IActionResult> UpdateRol([FromBody] RolViewModel rolViewModel)
        {
            try
            {
                var existRol = await rolService.GetRolById(rolViewModel.Rolid);
                if (existRol != null)
                {
                    mapper.Map(rolViewModel, existRol);
                    await rolService.UpdateRol(existRol);
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
                var existRol = await rolService.GetRolById(id);
                if (existRol != null)
                {
                    await rolService.DeleteRol(existRol);
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
