using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Reciplastk.Gateway.Models;
using Reciplastk.Gateway.Services;

namespace Reciplastk.Gateway.Controllers
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
        public HttpResponseModel Create(WeightControlTypeViewModel weightControlTypeViewModel)
        {
            var response = weightControlTypeService.Create(weightControlTypeViewModel);
            return response;
        }
        [HttpPost("Update")]
        public HttpResponseModel Update(WeightControlTypeViewModel weightControlTypeViewModel){
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
