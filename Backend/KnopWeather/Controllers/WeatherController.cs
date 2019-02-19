using KnopWeather.Api.Queries;
using KnopWeather.Data.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.ComponentModel.DataAnnotations;
using System.Threading.Tasks;

namespace KnopWeather.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class WeatherController : Controller
    {

        private readonly IForecastQueries _queries;

        public WeatherController(IForecastQueries queries)
        {
            _queries = queries ?? throw new ArgumentNullException(nameof(queries));
        }
        
        [HttpGet("[action]")]
        public async Task<ActionResult<ForecastModel>> Forecast([FromQuery, StringLength(100)]string city
            , [FromQuery, RegularExpression(@"(?!01000|99999)(0[1-9]\d{3}|[1-9]\d{4})")]string zipCode)
        {
            ForecastModel response = null;
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            response = await _queries.GetForecast(city, zipCode);
            if (response != null)
            {
                return Ok(response);
            }
            return NotFound();
        }



    }
}