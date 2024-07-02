using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
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
    }
}
