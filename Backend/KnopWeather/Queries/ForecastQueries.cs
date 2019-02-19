using KnopWeather.Data.Models;
using KnopWeather.Services.Forecast;
using System.Threading.Tasks;

namespace KnopWeather.Api.Queries
{
    public class ForecastQueries : IForecastQueries
    {
        IForecastService _service;
        public ForecastQueries(IForecastService service)
        {
            _service = service;
        }
        public Task<ForecastModel> GetForecast(string city, string zipCode)
        {
            return _service.GetForecast(city, zipCode);
        }
    }
}
