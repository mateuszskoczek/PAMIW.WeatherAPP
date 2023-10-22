using System; 
namespace WeatherAPP.Services.AccuWeather.Models.GetCities{ 

    public class TimeZone
    {
        public string Code { get; set; }
        public string Name { get; set; }
        public decimal GmtOffset { get; set; }
        public bool IsDaylightSaving { get; set; }
        public DateTime NextOffsetChange { get; set; }
    }

}