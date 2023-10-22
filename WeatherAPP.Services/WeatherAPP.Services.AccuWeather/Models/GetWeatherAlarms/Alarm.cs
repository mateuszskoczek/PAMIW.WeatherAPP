namespace WeatherAPP.Services.AccuWeather.Models.GetWeatherAlarms{ 

    public class Alarm
    {
        public string AlarmType { get; set; }
        public Value Value { get; set; }
        public Day Day { get; set; }
        public Night Night { get; set; }
    }

}