using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Reciplastk.Gateway.Models;
using Reciplastk.Gateway.Services;

namespace Reciplastk.Gateway.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CustomerController : ControllerBase
    {
        private readonly CustomerService customerService;

        public CustomerController(CustomerService custumerService)
        {
            this.customerService = custumerService;
        }

        [HttpGet("GetAll")]
        public HttpResponseModel GetAll() {
            var response = customerService.GetAll();
            return response;
        }

        [HttpGet("GetById")]
        public HttpResponseModel GetById(int id)
        {
            var response = customerService.Get(id);
            return response;
        }
        
        [HttpPost("Create")]
        public HttpResponseModel Create(CustomerViewModel customerViewModel)
        {
            var response = customerService.Create(customerViewModel);
            return response;
        }

        [HttpPost("Update")]
        public HttpResponseModel Update(CustomerViewModel customerViewModel)
        {
            var response = customerService.Update(customerViewModel);
            return response;
        }

        [HttpDelete("Delete")]
        public HttpResponseModel Delete(int id) { 
            var response = customerService.Delete(id);
            return response;
        }
    }
}
