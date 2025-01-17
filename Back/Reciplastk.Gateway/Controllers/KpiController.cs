using Microsoft.AspNetCore.Mvc;
using Reciplastk.Gateway.Models;
using Reciplastk.Gateway.Services;

namespace Reciplastk.Gateway.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class KpiController : ControllerBase
    {
        private readonly KpiService chartsService;

        public KpiController(KpiService kpiService)
        {
            this.chartsService = kpiService;
        }
        [HttpGet("GetSeparationSummary")]
        public HttpResponseModel GetSeparationSummary(bool isYearly, int month, int year)
        {
            return new HttpResponseModel { Data = chartsService.GetSeparationSummary(isYearly, month, year) };
        }
        [HttpGet("GetGrindingSummary")]
        public HttpResponseModel GetGrindingSummary(bool isYearly, int month, int year)
        {
            return new HttpResponseModel { Data = chartsService.GetGrindingSummary(isYearly, month, year) };
        }
        [HttpGet("GetShippingSummary")]
        public HttpResponseModel GetShippingSummary(bool isYearly, int month, int year)
        {
            return new HttpResponseModel { Data = chartsService.GetShippingSummary(isYearly, month, year) };
        }
        [HttpGet("GetBillingSummary")]
        public HttpResponseModel GetBillingSummary(bool isYearly, int month, int year)
        {
            return new HttpResponseModel { Data = chartsService.GetBillingSummary(isYearly, month, year) };
        }
        [HttpGet("GetShipmentGoal")]
        public HttpResponseModel GetShipmentGoal(bool isYearly, int month, int year)
        {
            return new HttpResponseModel { Data = chartsService.GetShipmentGoal(isYearly, month, year) };
        }
        [HttpGet("GetBillingGoal")]
        public HttpResponseModel GetBillingGoal(bool isYearly, int month, int year)
        {
            return new HttpResponseModel { Data = chartsService.GetBillingGoal(isYearly, month, year) };
        }

    }
}
