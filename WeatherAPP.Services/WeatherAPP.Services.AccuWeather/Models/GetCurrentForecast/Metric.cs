namespace WeatherAPP.Services.AccuWeather.Models.GetCurrentForecast{ 

    public class Metric
    {
        public double Value { get; set; }
        public string Unit { get; set; }
        public int UnitType { get; set; }
        public string Phrase { get; set; }
    }

}