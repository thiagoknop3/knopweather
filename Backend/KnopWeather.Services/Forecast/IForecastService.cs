using KnopWeather.Data.Models;
using System.Threading.Tasks;

namespace KnopWeather.Services.Forecast
{
    public interface IForecastService
    {
        Task<ForecastModel> GetForecast(string city, string zipCode);
    }
}
