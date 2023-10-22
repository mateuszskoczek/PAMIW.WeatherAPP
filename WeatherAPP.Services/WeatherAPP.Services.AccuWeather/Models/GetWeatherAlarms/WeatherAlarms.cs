using System.Collections.Generic; 
using System; 
namespace WeatherAPP.Services.AccuWeather.Models.GetWeatherAlarms{ 

    public class WeatherAlarms
    {
        public DateTime Date { get; set; }
        public int EpochDate { get; set; }
        public List<Alarm> Alarms { get; set; }
        public string MobileLink { get; set; }
        public string Link { get; set; }
    }

}