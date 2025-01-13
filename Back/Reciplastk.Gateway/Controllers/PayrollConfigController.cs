using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Reciplastk.Gateway.Models;
using Reciplastk.Gateway.Services;

namespace Reciplastk.Gateway.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PayrollConfigController : ControllerBase
    {
        private readonly PayrollConfigService payrollConfigService;
        public PayrollConfigController (PayrollConfigService payrollConfigService)
        {
            this.payrollConfigService = payrollConfigService;
        }
        [HttpGet("GetAll")]
        public HttpResponseModel GetAll()
        {
            return this.payrollConfigService.GetAll();
        }
        [HttpGet("GetById")]
        public HttpResponseModel GetById(int id)
        {
            return this.payrollConfigService.GetById(id);
        }
        [HttpPost("Create")]
        public HttpResponseModel Create(PayrollConfigViewModel payrollConfigViewModel)
        {
            return this.payrollConfigService.Create(payrollConfigViewModel);
        }
        [HttpPost("Update")]
        public HttpResponseModel Update(PayrollConfigViewModel payrollConfigViewModel)
        {
            return this.payrollConfigService.Update(payrollConfigViewModel);
        }
        [HttpDelete("Delete")]
        public HttpResponseModel Delete(int id)
        {
            return this.payrollConfigService.Delete(id);
        }
    }
}
