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
        [HttpGet("GetAll")]
        public HttpResponseModel GetAll() 
        {
            var response = shipmentTypeService.GetAll();
            return response;
        }
        [HttpGet("GetById")]
        public HttpResponseModel GetById(int shipmentTypeId)
        {
            var response = shipmentTypeService.GetById(shipmentTypeId);
            return response;
        }
        [HttpPost("Create")]
        public HttpResponseModel Create(ShipmentTypeViewModel shipmentTypeViewModel)
        {
            var response = shipmentTypeService.Create(shipmentTypeViewModel);
            return response;
        }
        [HttpPost("Update")]
        public HttpResponseModel Update(ShipmentTypeViewModel shipmentTypeViewModel)
        {
            var response = shipmentTypeService.Update(shipmentTypeViewModel);
            return response;
        }
        [HttpDelete("Delete")]
        public HttpResponseModel Delete(int shipmentTypeId)
        {
            var response = shipmentTypeService.Delete(shipmentTypeId);
            return response;
        }
    }
}
