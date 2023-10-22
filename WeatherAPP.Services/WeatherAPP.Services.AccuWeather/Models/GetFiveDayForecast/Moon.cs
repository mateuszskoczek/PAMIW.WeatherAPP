using System; 
namespace WeatherAPP.Services.AccuWeather.Models.GetFiveDayForecast{ 

    public class Moon
    {
        public DateTime Rise { get; set; }
        public int EpochRise { get; set; }
        public DateTime Set { get; set; }
        public int EpochSet { get; set; }
        public string Phase { get; set; }
        public int Age { get; set; }
    }

}