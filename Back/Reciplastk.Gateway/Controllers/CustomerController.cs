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
        private readonly CustumerService custumerService;

        public CustomerController(CustumerService custumerService)
        {
            this.custumerService = custumerService;
        }

        [HttpGet("Show all customers")]
        public HttpResponseModel ShowAllCustomers() {
            var response = custumerService.ShowAllCustomers();
            return response;
        }

        [HttpGet("Show a customer")]
        public HttpResponseModel ShowCustomer(int id)
        {
            var response = custumerService.ShowCustomer(id);
            return response;
        }
        
        [HttpPost("Create customer")]
        public HttpResponseModel CreateCustomer(CustomerViewModel customerViewModel)
        {
            var response = custumerService.CreateCustomer(customerViewModel);
            return response;
        }

        [HttpPost("Edit customer")]
        public HttpResponseModel EditCustomer(CustomerViewModel customerViewModel)
        {
            var response = custumerService.EditCustomer(customerViewModel);
            return response;
        }

        [HttpDelete("Delete customer")]
        public HttpResponseModel DeleteCustomer(int id) { 
            var response = custumerService.DeleteCustomer(id);
            return response;
        }


    }
}
