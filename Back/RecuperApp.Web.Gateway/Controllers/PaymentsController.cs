using Azure;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RecuperApp.Common.Models;
using RecuperApp.Domain.Models.Requests;
using RecuperApp.Domain.Services.Interfaces;

namespace RecuperApp.Web.Gateway.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PaymentsController : ControllerBase
    {
        private readonly IPaymentService paymentService;

        public PaymentsController(IPaymentService paymentService)
        {
            this.paymentService = paymentService;
        }
        [HttpPost("Create")]
        public async Task<HttpResponseModel> PayAndSave(PaymentReceiptRequest viewModel)
        {
            var response = await paymentService.Create(viewModel);
            return new HttpResponseModel(response, $"Se creó el pago exitosamente con id #{response.Id}");

        }

        [HttpGet("GetAllReceipt")]
        public async Task<HttpResponseModel> GetAllReceipt()
        {
            var response = await paymentService.GetAllReceipt();
            return new HttpResponseModel(response);

        }

        [HttpGet("GetReceipt")]
        public async Task<HttpResponseModel> GetReceipt(int id)
        {
            var response = await paymentService.GetReceipt(id);
            return new HttpResponseModel(response);

        }
    }
}
