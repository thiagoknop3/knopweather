using KnopWeather.Data.Models;
using Microsoft.AspNetCore.WebUtilities;
using System.Collections.Specialized;
using System.Net.Http;
using System.Threading.Tasks;

namespace KnopWeather.Services.Forecast
{
    public class ForecastService : IForecastService
    {
        private string _serviceUrl;
        private string _country;
        private static readonly HttpClient client = new HttpClient();
        private string errorMessage = "Error in external forecast service";
        NameValueCollection queryString;

        public ForecastService(string serviceUrl, string country)
        {
            _serviceUrl = serviceUrl;
            _country = country;
            CreateClientService();
        }

        private void CreateClientService()
        {
            client.DefaultRequestHeaders.Accept.Clear();
            queryString = System.Web.HttpUtility.ParseQueryString(_serviceUrl);
        }

        public async Task<ForecastModel> GetForecast(string city, string zipCode)
        {
            try
            {
                if (!string.IsNullOrEmpty(city))
                    _serviceUrl = QueryHelpers.AddQueryString(_serviceUrl, "q", city + "," + _country);

                if (!string.IsNullOrEmpty(zipCode))
                    _serviceUrl = QueryHelpers.AddQueryString(_serviceUrl, "zip", zipCode + "," + _country);

                var stringTask = client.GetStringAsync(_serviceUrl);
                var msg = await stringTask;
                return Mappers.ForecastMapper.Map(msg);
            }
            catch (HttpRequestException)
            {
                //force return empty
                //probably get 404(not found)                
                return new ForecastModel();
            }
            catch (System.Exception)
            {
                throw new System.Exception(errorMessage);
            }

        }

    }

}
