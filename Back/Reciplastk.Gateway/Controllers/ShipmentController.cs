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
        public HttpResponseModel Create(ShipmentViewModel shipmentViewModel)
        {
            var response = shipmentService.Create(shipmentViewModel);
            return response;
        }

        [HttpPost("CreateDetail")]
        public HttpResponseModel CreateDetail(ShipmentDetailViewModel shipmentDetailViewModel)
        {
            var response = shipmentService.CreateDetail(shipmentDetailViewModel);
            return response;
        }

        [HttpPost("Update")]
        public HttpResponseModel Update(ShipmentViewModel shipmentViewModel)
        {
            var response = shipmentService.Update(shipmentViewModel);
            return response;
        }
        [HttpDelete("Delete")]
        public HttpResponseModel Delete(int shipmentid)
        {
            var response = shipmentService.Delete(shipmentid);
            return response;
        }
    }
}
