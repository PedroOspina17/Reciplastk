using Microsoft.AspNetCore.Mvc;
using RecuperApp.Common.Models;
using RecuperApp.Domain.Models.Requests;
using RecuperApp.Domain.Services;

namespace RecuperApp.Web.Gateway.Controllers
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
        public HttpResponseModel Create(CustomerTypeRequest customerTypeViewModel)
        {
            var response = customerTypeService.Create(customerTypeViewModel);
            return response;
        }
        [HttpPost("Update")]
        public HttpResponseModel Update(CustomerTypeRequest customerTypeViewModel)
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
