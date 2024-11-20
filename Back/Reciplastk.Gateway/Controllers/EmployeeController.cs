using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Reciplastk.Gateway.Common;
using Reciplastk.Gateway.DataAccess;
using Reciplastk.Gateway.Models;
using Reciplastk.Gateway.Services;

namespace Reciplastk.Gateway.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeeController : ControllerBase
    {
        private readonly IEmployeeService employeeService;
        private readonly IMapper mapper;

        public EmployeeController(IEmployeeService _employeeService, IMapper _mapper)
        {
            employeeService = _employeeService;
            mapper = _mapper;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllEmployee()
        {
            try
            {
                var EmployeeList = await employeeService.GetAllEmployee();
                if (EmployeeList == null || EmployeeList.Count == 0)
                {
                    return Ok(new { message = "Not employee created" });
                }
                return Ok(EmployeeList);

            }
            catch (Exception ex)
            {

                return BadRequest(ex.Message);
            }

        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetEmployeeById(int id)
        {
            try
            {
                var employee = await employeeService.GetEmployeeById(id);
                if (employee == null)
                {
                    return NotFound(new { message = "Not data found" });
                }
                return Ok(employee);
            }
            catch (Exception ex)
            {

                return BadRequest(ex.Message);
            }
        }


        [HttpPost]
        public async Task<IActionResult> AddEmployee([FromBody] EmployeeViewModel employeeViewModel)
        {
            var ExistEmployee = await employeeService.GetEmployeeByName(employeeViewModel.Name);

            if (ExistEmployee == null)
            {
                employeeViewModel.Password = Encrypt.EncryptPassword(employeeViewModel.Password);

                var employee = mapper.Map<Employee>(employeeViewModel);
                await employeeService.AddEmployee(employee);
                return Ok(new { message = "Employee creaded successfylly" });

            }

            return Ok(new { message = "The employee" + employeeViewModel.Name + "already exists" });
        }


        [HttpPut]
        public async Task<IActionResult> UpdateEmployee([FromBody] EmployeeViewModel employeeViewModel)
        {
            Employee employee = await employeeService.GetEmployeeById(employeeViewModel.Employeeid);
            if (employee != null)
            {
                employeeViewModel.Password = Encrypt.EncryptPassword(employeeViewModel.Password);
                mapper.Map(employeeViewModel, employee);
                await employeeService.UpdateEmployee(employee);
                return Ok(new { message = "Employee edited successfylly" });

            }

            return Ok(new { message = "The employee not exists" });
        }


        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteEmployee(int id)
        {
            var ExistEmployee = await employeeService.GetEmployeeById(id);
            if (ExistEmployee != null)
            {
                await employeeService.DeleteEmployee(ExistEmployee);
                return Ok(new { message = "Employee deleted successfylly" });

            }

            return Ok(new { message = "The employee not exists" });
        }
    }
}
