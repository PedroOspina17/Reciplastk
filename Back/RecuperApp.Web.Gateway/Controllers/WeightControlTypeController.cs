using Microsoft.AspNetCore.Mvc;
using RecuperApp.Common.Models;
using RecuperApp.Domain.Models.Requests;
using RecuperApp.Domain.Services;

namespace RecuperApp.Web.Gateway.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class WeightControlTypeController : ControllerBase
    {
        private readonly WeightControlTypeService weightControlTypeService;
        public WeightControlTypeController(WeightControlTypeService weightControlTypeService)
        {
            this.weightControlTypeService = weightControlTypeService;
        }
        [HttpGet("GetAll")]                    
        public HttpResponseModel GetAll(){
            var response = weightControlTypeService.GetAll();
            return response;
        }
        [HttpGet("GetById")]
        public HttpResponseModel GetById(int id){
            var response = weightControlTypeService.GetById(id);
            return response;
        }
        [HttpPost("Create")]
        public HttpResponseModel Create(WeightControlTypeRequest weightControlTypeModel)
        {
            var response = weightControlTypeService.Create(weightControlTypeModel);
            return response;
        }
        [HttpPost("Update")]
        public HttpResponseModel Update(WeightControlTypeRequest weightControlTypeViewModel){
            var response = weightControlTypeService.Update(weightControlTypeViewModel);
            return response;
        }
        [HttpDelete("Delete")]
        public HttpResponseModel Delete(int id){
            var response = weightControlTypeService.Delete(id);
            return response;
        
        }
    }
}
