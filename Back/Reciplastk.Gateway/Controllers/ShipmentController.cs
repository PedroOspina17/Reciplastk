using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Reciplastk.Gateway.Models;
using Reciplastk.Gateway.Services;

namespace Reciplastk.Gateway.Controllers
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
        [HttpGet("ShowAllShipment")]
        public HttpResponseModel ShowAllShipment()
        {
            var response = shipmentService.ShowAllShipment();
            return response;
        }
        [HttpGet("ShowShipment")]
        public HttpResponseModel ShowShipment(int shipmentid)
        {
            var response = shipmentService.ShowShipment(shipmentid);
            return response;
        }
        [HttpPost("CreateShipment")]
        public HttpResponseModel CreateShipment(ShipmentViewModel shipmentViewModel)
        {
            var response = shipmentService.CreateShipment(shipmentViewModel);
            return response;
        }
        [HttpPost("EditShipment")]
        public HttpResponseModel EditShipment(ShipmentViewModel shipmentViewModel)
        {
            var response = shipmentService.EditShipment(shipmentViewModel);
            return response;
        }
        [HttpDelete("DeleteShipment")]
        public HttpResponseModel DeleteShipment(int shipmentid)
        {
            var response = shipmentService.DeleteShipment(shipmentid);
            return response;
        }
    }
}
