using Microsoft.AspNetCore.Mvc;
using RecuperApp.Common.Models;
using RecuperApp.Domain.Models.EntityModels;
using RecuperApp.Domain.Models.Requests;
using RecuperApp.Domain.Services.Interfaces;

namespace RecuperApp.Web.Gateway.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class WeightControlTypeController : ControllerBase
    {
        private readonly IApplicationService<WeightControlType, WeightControlTypeRequest> weightControlTypeService;
        public WeightControlTypeController(IApplicationService<WeightControlType, WeightControlTypeRequest> weightControlTypeService)
        {
            this.weightControlTypeService = weightControlTypeService;
        }
        [HttpGet("GetAll")]                    
        public async Task<HttpResponseModel> GetAll(){
            var response = await weightControlTypeService.GetAll();
            return new HttpResponseModel(response);
        }
        [HttpGet("GetById")]
        public async Task<HttpResponseModel> GetById(int id){
            var response = await weightControlTypeService.GetById(id);
            return new HttpResponseModel(response);
        }
        [HttpPost("Create")]
        public async Task<HttpResponseModel> Create(WeightControlTypeRequest weightControlTypeModel)
        {
            var response = await weightControlTypeService.Create(weightControlTypeModel);
            return new HttpResponseModel(response);
        }
        [HttpPost("Update")]
        public async Task<HttpResponseModel> Update(WeightControlTypeRequest weightControlTypeViewModel){
            var response = await weightControlTypeService.Update(weightControlTypeViewModel);
            return new HttpResponseModel(response);
        }
        [HttpDelete("Delete")]
        public async Task<HttpResponseModel> Delete(int id){
            var response = await weightControlTypeService.Delete(id);
            return new HttpResponseModel(response);
        
        }
    }
}
