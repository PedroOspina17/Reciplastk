using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Reciplastk.Gateway.Models;
using Reciplastk.Gateway.Services;

namespace Reciplastk.Gateway.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CustomerTypeController : ControllerBase
    {
        private readonly CustomerTypeService customerTypeService;
        public CustomerTypeController(CustomerTypeService customerTypeService)
        {
            this.customerTypeService = customerTypeService;
        }
        [HttpGet("GetAll")]
        public HttpResponseModel GetAll()
        {
            var response = customerTypeService.GetAll();
            return response;
        }
        [HttpGet("GetById")]
        public HttpResponseModel GetById(int customerTypeId)
        {
            var response = customerTypeService.GetById(customerTypeId);
            return response;
        }
        [HttpPost("Create")]
        public HttpResponseModel Create(CustomerTypeViewModel customerTypeViewModel)
        {
            var response = customerTypeService.Create(customerTypeViewModel);
            return response;
        }
        [HttpPost("Update")]
        public HttpResponseModel Update(CustomerTypeViewModel customerTypeViewModel)
        {
            var response = customerTypeService.Update(customerTypeViewModel);
            return response;
        }
        [HttpDelete("Delete")]
        public HttpResponseModel Delete(int customerTypeId)
        {
            var response = customerTypeService.Delete(customerTypeId);
            return response;
        }
    }
}
