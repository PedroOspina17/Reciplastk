using Microsoft.AspNetCore.Mvc;
using RecuperApp.Common.Models;
using RecuperApp.Domain.Models.ViewModels;
using RecuperApp.Domain.Services;

namespace RecuperApp.Web.Gateway.Controllers
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
        public HttpResponseModel GetAll()
        {
            var response = customerService.GetAll();
            return response;
        }
        [HttpGet("GetAllCustomer")]
        public HttpResponseModel GetAllCustomer() {
            var response = customerService.GetAllCustomer();
            return response;
        }
        [HttpGet("GetAllProviders")]
        public HttpResponseModel GetAllProviders()
        {
            var response = customerService.GetAllProviders();
            return response;
        }

        [HttpGet("GetCustomer")]
        public HttpResponseModel GetCustomer(int id)
        {
            var response = customerService.GetCustomer(id);
            return response;
        }
        [HttpGet("GetProvider")]
        public HttpResponseModel GetProvider(int id)
        {
            var response = customerService.GetProvider(id);
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
