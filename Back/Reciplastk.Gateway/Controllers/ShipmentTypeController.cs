using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Reciplastk.Gateway.Models;
using Reciplastk.Gateway.Services;

namespace Reciplastk.Gateway.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ShipmentTypeController : ControllerBase
    {
        private readonly ShipmentTypeService shipmentTypeService;
        public ShipmentTypeController (ShipmentTypeService shipmentTypeService)
        {
            this.shipmentTypeService = shipmentTypeService;
        }
        [HttpGet("ShowAllShipmentTypes")]
        public HttpResponseModel ShowAllShipmentTypes() 
        {
            var response = shipmentTypeService.ShowAllShipmentTypes();
            return response;
        }
        [HttpGet("ShowShipmentType")]
        public HttpResponseModel ShowShipmentType(int shipmentTypeId)
        {
            var response = shipmentTypeService.ShowShipmentType(shipmentTypeId);
            return response;
        }
        [HttpPost("CreateShipmentType")]
        public HttpResponseModel CreateShipmentType(ShipmentTypeViewModel shipmentTypeViewModel)
        {
            var response = shipmentTypeService.CreateShipmentType(shipmentTypeViewModel);
            return response;
        }
        [HttpPost("EditShipmentType")
        public HttpResponseModel EditShipmentType(ShipmentTypeViewModel shipmentTypeViewModel)
        {
            var response = shipmentTypeService.EditShipmentType(shipmentTypeViewModel);
            return response;
        }
        [HttpDelete("DeleteShipmentType")]
        public HttpResponseModel DeleteShipmentType(int shipmentTypeId)
        {
            var response = shipmentTypeService.DeleteShipmentType(shipmentTypeId);
            return response;
        }
    }
}
