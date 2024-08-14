using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc;
using Reciplastk.Gateway.Models;
using Reciplastk.Gateway.Services;

namespace Reciplastk.Gateway.Controllers
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

        [HttpPost("Create")]

        public HttpResponseModel Create(WeightControlViewModel viewModel)
        {
            return weightControlService.Create(viewModel);
        }

        [HttpPost("Update")]

        public HttpResponseModel Update(WeightControlViewModel viewModel)
        {
            return weightControlService.Update(viewModel);
        }

        [HttpPost("Delete")]
        public HttpResponseModel Delete(int id)
        {
            return weightControlService.Delete(id);
        }



    }
}
