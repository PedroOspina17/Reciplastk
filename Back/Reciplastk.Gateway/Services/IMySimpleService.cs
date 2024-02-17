using Reciplastk.Gateway.Models;

namespace Reciplastk.Gateway.Services
{
    public interface IMySimpleService
    {
        string GetText();
        List<WeatherForecast> GetForecastWeather();
    }
}