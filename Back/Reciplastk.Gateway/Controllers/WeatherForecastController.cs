using Microsoft.AspNetCore.Mvc;
using Reciplastk.Gateway.Models;
using Reciplastk.Gateway.Services;

namespace Reciplastk.Gateway.Controllers
{

    [ApiController]
    [Route("[controller]")]
    public class WeatherForecastController : ControllerBase
    {
        
        private readonly ILogger<WeatherForecastController> _logger;
        private readonly IMySimpleService mySimpleService;

        public WeatherForecastController(ILogger<WeatherForecastController> logger, IMySimpleService mySimpleService)
        {
            _logger = logger;
            this.mySimpleService = mySimpleService;
        }

        [HttpGet("Text")]
        public string GetText()
        {
            _logger.LogDebug("The GET/Text endpoint was executed !!");
            return mySimpleService.GetText();
        }

        [HttpGet("GetWeatherForecast")]
        public IEnumerable<WeatherForecast> GetForecast()
        {
            _logger.LogDebug("The GET/Forecast endpoint was executed !!");
            return mySimpleService.GetForecastWeather();
        }
    }
}
