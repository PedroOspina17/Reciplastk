using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Reciplastk.Common.Helpers;
using Reciplastk.Gateway.Models;
using Reciplastk.Gateway.Services;

namespace Reciplastk.Gateway.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ChartsController : ControllerBase
    {
        private readonly ChartsService chartsService;

        public ChartsController(ChartsService chartsService)
        {
            this.chartsService = chartsService;
        }
        [HttpGet("GetEmployeeComparisonInfo")]
        public List<EmployeeComparisonsViewModel> GetEmployeeComparisonInfo()
        {
            return chartsService.GetEmployeeComparisonInfo();
        }
    }
}
