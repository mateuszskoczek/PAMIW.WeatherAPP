namespace WeatherAPP.Services.AccuWeather.Models.GetHistoricalForecast{ 

    public class Temperature
    {
        public Metric Metric { get; set; }
        public Imperial Imperial { get; set; }
    }

}