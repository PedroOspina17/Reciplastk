using Microsoft.AspNetCore.Mvc;
using RecuperApp.Common.Models;
using RecuperApp.Domain.Models.EntityModels;
using RecuperApp.Domain.Models.Requests;
using RecuperApp.Domain.Services.Interfaces;

namespace RecuperApp.Web.Gateway.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class WeightControlController : ControllerBase
    {
        private readonly IWeightControlService weightControlService;

        public WeightControlController(IWeightControlService weightControlService)
        {
            this.weightControlService = weightControlService;
        }

        [HttpGet("GetAll")]

        public async Task<HttpResponseModel> GetAll()
        {
            var response = await weightControlService.GetAll();
            return new HttpResponseModel(response);
        }

        [HttpGet("GetById")]
        public async Task<HttpResponseModel> GetById(int id)
        {
            var response = await weightControlService.GetById(id);
            return new HttpResponseModel(response);
        }

        [HttpPost("CreateSeparation")]

        public async Task<HttpResponseModel> Create(WeightControlSeparationRequest viewModel)
        {
            var response = await weightControlService.CreateSeparation(viewModel);
            return new HttpResponseModel(response, $"Se creó el registro de separación de peso exitosamente con id #{response.Id}");
        }

        [HttpPost("CreateGrinding")]
        public async Task<HttpResponseModel> CreateGrinding(WeightControlGrindingRequest grindingViewModel)
        {
            var response = await weightControlService.CreateGrinding(grindingViewModel);
            return new HttpResponseModel(response, $"Se creó el registro de material molidoexitosamente con id #{response.Id}");
        }

        [HttpPost("Update")]
        public async Task<HttpResponseModel> Update(WeightControl viewModel)
        {
            var response = await weightControlService.Update(viewModel);
            return new HttpResponseModel(response);
        }

        [HttpDelete("Delete")]
        public async Task<HttpResponseModel> Delete(int id)
        {
            var response = await weightControlService.Delete(id);
            return new HttpResponseModel(response);
        }

        [HttpGet("GetGroundProducts")]
        public async Task<HttpResponseModel> GetGroundProducts()
        {
            var response = await weightControlService.GetGroundProducts();
            return new HttpResponseModel(response);
        }

        [HttpPost("Filter")]
        public async Task<HttpResponseModel> Filter(WeightControlReportRequest weightControlReportParams)
        {
            var response = await weightControlService.Filter(weightControlReportParams);
            return new HttpResponseModel(response);
        }

        [HttpGet("Remainings")]
        public async Task<HttpResponseModel> Remainings (bool ViewAll)
        {
            var response = await weightControlService.Remainings(ViewAll);
            return new HttpResponseModel(response);
        }

       
    }
}