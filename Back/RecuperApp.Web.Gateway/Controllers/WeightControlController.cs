using Microsoft.AspNetCore.Mvc;
using RecuperApp.Common.Models;
using RecuperApp.Domain.Models.Requests;
using RecuperApp.Domain.Services;

namespace RecuperApp.Web.Gateway.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class WeightControlController : ControllerBase
    {
        private readonly WeightControlService weightControlService;

        public WeightControlController(WeightControlService weightControlService)
        {
            this.weightControlService = weightControlService;
        }

        [HttpGet("GetAll")]

        public HttpResponseModel GetAll()
        {
            return weightControlService.GetAll();
        }

        [HttpGet("GetById")]
        public HttpResponseModel GetById(int id)
        {
            return weightControlService.GetById(id);
        }

        [HttpPost("CreateSeparation")]

        public HttpResponseModel Create(WeightControlSeparationRequest viewModel)
        {
            return weightControlService.CreateSeparation(viewModel);
        }

        [HttpPost("CreateGrinding")]
        public HttpResponseModel CreateGrinding(WeightControlGrindingRequest grindingViewModel)
        {
            return weightControlService.CreateGrinding(grindingViewModel);
        }

        [HttpPost("Update")]
        public HttpResponseModel Update(WeightControlSeparationRequest viewModel)
        {
            return weightControlService.Update(viewModel);
        }

        [HttpDelete("Delete")]
        public HttpResponseModel Delete(int id)
        {
            return weightControlService.Delete(id);
        }

        [HttpGet("GetGroundProducts")]
        public HttpResponseModel GetGroundProducts()
        {
            return weightControlService.GetGroundProducts();
        }

        [HttpPost("Filter")]
        public HttpResponseModel Filter(WeightControlReportRequest weightControlReportParams)
        {
            return weightControlService.Filter(weightControlReportParams);
        }

        [HttpGet("Remainings")]
        public HttpResponseModel Remainings (bool ViewAll)
        {
            return weightControlService.Remainings(ViewAll);
        }

        [HttpPost("PayAndSave")]
        public HttpResponseModel PayAndSave(PaymentReceiptRequest viewModel)
        {
            return weightControlService.PayAndSave(viewModel);
        }

        [HttpGet("GetAllReceipt")]
        public HttpResponseModel GetAllReceipt() {
            return weightControlService.GetAllReceipt();
        }

        [HttpGet("GetReceipt")]
        public HttpResponseModel GetReceipt(int id)
        {
            return weightControlService.GetReceipt(id);
        }
    }
}