namespace WeatherAPP.Services.AccuWeather.Models.GetFiveDayForecast{ 

    public class Minimum
    {
        public double Value { get; set; }
        public string Unit { get; set; }
        public int UnitType { get; set; }
        public string Phrase { get; set; }
    }

}