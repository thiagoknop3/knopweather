using System;
using System.Collections.Generic;

namespace KnopWeather.Data.Models
{
    public class ForecastModel
    {
        public string City { get; set; }
        public string Country { get; set; }
        public List<DateModel> Dates { get; set; }

    }

    public class DateModel
    {
        public DateTime Date { get; set; }
        public List<HourModel> Hours { get; set; }    

    }

    public class HourModel
    {
        public int Hour { get; set; }
         public int WeatherId { get; set; }
        public int Humidity { get; set; }
        public TemperatureModel Temperature { get; set; }
        public double WindSpeed { get; set; }
    }

    public class TemperatureModel
    {
        public double MinTemperature { get; set; }
        public double MaxTemperature { get; set; }
    }
}