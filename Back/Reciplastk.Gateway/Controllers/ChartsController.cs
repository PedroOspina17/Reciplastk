using Microsoft.AspNetCore.Mvc;
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
        public HttpResponseModel GetEmployeeComparisonInfo(bool yearlyChart = false, int year = 2025, int month = 1)
        {
            return new HttpResponseModel { Data = chartsService.GetEmployeeComparisonInfo(yearlyChart,year, month) };
        }
    }
}
