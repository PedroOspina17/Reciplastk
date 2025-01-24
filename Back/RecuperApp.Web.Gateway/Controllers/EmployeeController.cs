using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using RecuperApp.Common.Helpers;
using RecuperApp.Common.Models;
using RecuperApp.Domain.Models.Requests;
using RecuperApp.Domain.Services;

namespace RecuperApp.Web.Gateway.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeeController : ControllerBase
    {
        private readonly IEmployeeService employeeService;

        public EmployeeController(IEmployeeService _employeeService)
        {
            employeeService = _employeeService;
        }

        [HttpGet]
        public async Task<HttpResponseModel> GetAll()
        {
            var result = await employeeService.GetAll();
            return new HttpResponseModel(result);
        }

        [HttpGet("{id}")]
        public async Task<HttpResponseModel> GetById(int id)
        {
            var result = await employeeService.GetById(id);
            return new HttpResponseModel(result);
        }


        [HttpPost]
        public async Task<HttpResponseModel> Create([FromBody] EmployeeRequest employeeViewModel)
        {
            var result = await employeeService.Create(employeeViewModel);
            return new HttpResponseModel(result, $"El empleado ${result.Name} fué creado con exito, con el id #${result.EmployeeId}");
        }


        [HttpPut]
        public async Task<HttpResponseModel> Update([FromBody] EmployeeRequest employeeViewModel)
        {
            var result = await employeeService.Create(employeeViewModel);
            return new HttpResponseModel(result, $"El empleado ${result.Name} fué modificado con exito");
        }


        [HttpDelete("{id}")]
        public async Task<HttpResponseModel> Delete(int id)
        {
            var result = await employeeService.Delete(id);
            return new HttpResponseModel(result, $"El empleado ${result.Name} fué eliminado con exito");
        }
    }
}
