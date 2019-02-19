using KnopWather.Data.Services;
using KnopWeather.Data.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;

namespace KnopWeather.Services.Mappers
{
    public static class ForecastMapper
    {
        public static ForecastModel Map(string json)
        {
            var model = JsonConvert.DeserializeObject<ForecastServiceModel>(json);
            return new ForecastModel
            {
                City = model.City.Name,
                Country = model.City.Country,
                Dates = CreateDayList(model.List)

            };
        }

        private static List<DateModel> CreateDayList(List<List> dayList)
        {
            List<DateModel> listDate = new List<DateModel>();
            foreach (List day in dayList)
            {
                DateTime dateAndHour;
                DateTime.TryParse(day.Dt_txt, out dateAndHour);
                if (dateAndHour != null)
                {
                    var dateModel = listDate.Find(l => l.Date == dateAndHour.Date);
                    if (dateModel == null)
                    {
                        dateModel = new DateModel
                        {
                            Date = dateAndHour.Date,
                            Hours = new List<HourModel>()
                        };
                        listDate.Add(dateModel);
                    }

                    var hourModel = dateModel.Hours.Find(h => h.Hour == dateAndHour.Hour);
                    if (hourModel == null)
                    {
                        dateModel.Hours.Add(new HourModel
                        {
                            WeatherId = day.Weather != null ? day.Weather[0].Id : 0,
                            Hour = dateAndHour.Hour,
                            Humidity = day.Main.Humidity,
                            Temperature = new TemperatureModel
                            {
                                MaxTemperature = day.Main.Temp_max,
                                MinTemperature = day.Main.Temp_min
                            },
                            WindSpeed = day.Wind == null ? default(double) : day.Wind.Speed
                        });
                    }
                    
                }
            }
            return listDate;
        }
    }
}
