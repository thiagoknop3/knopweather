using KnopWeather.Data.Models;
using System.Threading.Tasks;

namespace KnopWeather.Api.Queries
{
    public interface IForecastQueries
    {
        Task<ForecastModel> GetForecast(string city, string zipCode);
    }
}
