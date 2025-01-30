using Microsoft.AspNetCore.Mvc;
using RecuperApp.Common.Models;
using RecuperApp.Domain.Models.EntityModels;
using RecuperApp.Domain.Models.Requests;
using RecuperApp.Domain.Services.Interfaces;

namespace RecuperApp.Web.Gateway.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ShipmentTypeController : ControllerBase
    {
        private readonly IShipmentTypeService shipmentTypeService;
        public ShipmentTypeController (IShipmentTypeService shipmentTypeService)
        {
            this.shipmentTypeService = shipmentTypeService;
        }
        [HttpGet("GetAll")]
        public async Task<HttpResponseModel> GetAll() 
        {
            var response = await shipmentTypeService.GetAll();
            return new HttpResponseModel(response);
        }
        [HttpGet("GetById")]
        public async Task<HttpResponseModel> GetById(int shipmentTypeId)
        {
            var response = await shipmentTypeService.GetById(shipmentTypeId);
            return new HttpResponseModel(response);
        }
        [HttpPost("Create")]
        public async Task<HttpResponseModel> Create(ShipmentTypeRequest shipmentTypeViewModel)
        {
            var response = await shipmentTypeService.Create(shipmentTypeViewModel);
            return new HttpResponseModel(response, $"Se creó el tipo de envío {response.Name} exitosamente con id #{response.Id}");
        }
        [HttpPost("Update")]
        public async Task<HttpResponseModel> Update(ShipmentTypeRequest shipmentTypeViewModel)
        {
            var response = await shipmentTypeService.Update(shipmentTypeViewModel);
            return new HttpResponseModel(response, $"Se actualizó el tipo de envío {response.Name} exitosamente");

        }
        [HttpDelete("Delete")]
        public async Task<HttpResponseModel> Delete(int shipmentTypeId)
        {
            var response = await shipmentTypeService.Delete(shipmentTypeId);
            return new HttpResponseModel(response, $"Se eliminó el tipo de envío {response.Name} exitosamente");
        }
    }
}
