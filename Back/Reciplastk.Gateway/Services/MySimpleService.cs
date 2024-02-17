using Reciplastk.Gateway.Models;

namespace Reciplastk.Gateway.Services
{
    public class MySimpleService : IMySimpleService
    {
        private static readonly string[] Summaries = new[]
        {
            "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
        };


        public string GetText()
        {
            return "This is a test !! \n the service is working...";
        }

        public List<WeatherForecast> GetForecastWeather()
        {
            return Enumerable.Range(1, 5).Select(index => new WeatherForecast
            {
                Date = DateOnly.FromDateTime(DateTime.Now.AddDays(index)),
                TemperatureC = Random.Shared.Next(-20, 55),
                Summary = Summaries[Random.Shared.Next(Summaries.Length)]
            })
            .ToList();
        }


    }
}
