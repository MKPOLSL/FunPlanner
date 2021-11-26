using Refit;

namespace FunPlannerShared.Controllers
{
    public interface IWeatherForecastController
    {
        [Get("/WeatherForecast")]
        Task<IEnumerable<WeatherForecast>> Get();
    }
}
