using Microsoft.AspNetCore.Mvc;
using RecuperApp.Common.Models;
using RecuperApp.Domain.Models.Requests;
using RecuperApp.Domain.Services;

namespace RecuperApp.Web.Gateway.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ShipmentController : ControllerBase
    {
        private readonly ShipmentService shipmentService;
        public ShipmentController(ShipmentService shipmentService)
        {
            this.shipmentService = shipmentService;
        }
        [HttpGet("GetAll")]
        public HttpResponseModel GetAll()
        {
            var response = shipmentService.GetAll();
            return response;
        }
        [HttpGet("GetById")]
        public HttpResponseModel GetById(int shipmentid)
        {
            var response = shipmentService.GetById(shipmentid);
            return response;
        }
        [HttpPost("Create")]
        public HttpResponseModel Create(ShipmentRequest shipmentViewModel)
        {
            var response = shipmentService.Create(shipmentViewModel);
            return response;
        }
        
        [HttpDelete("Delete")]
        public HttpResponseModel Delete(int shipmentid)
        {
            var response = shipmentService.Delete(shipmentid);
            return response;
        }

        [HttpPost("Filter")]
        public HttpResponseModel Filter(ShipmentReportRequest model)
        {
            var response = shipmentService.Filter(model);
            return response;
        }
        [HttpGet("GetShipmentForPayments")]

        public HttpResponseModel GetShipmentForPayments(int id)
        {
            return shipmentService.GetShipmentForPayments(id);
        }
        [HttpGet("GetReceivableReceiptInfo")]
        public HttpResponseModel GetReceivableReceiptInfo(int id)
        {
            return shipmentService.GetReceivableReceiptInfo(id);
        }
    }
}
