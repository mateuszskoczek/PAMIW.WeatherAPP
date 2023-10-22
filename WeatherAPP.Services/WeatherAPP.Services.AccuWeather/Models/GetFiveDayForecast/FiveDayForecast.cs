using System.Collections.Generic; 
namespace WeatherAPP.Services.AccuWeather.Models.GetFiveDayForecast{ 

    public class FiveDayForecast
    {
        public Headline Headline { get; set; }
        public List<DailyForecast> DailyForecasts { get; set; }
    }

}