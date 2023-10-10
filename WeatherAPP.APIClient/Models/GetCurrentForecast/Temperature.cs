namespace WeatherAPP.APIClient.Models.GetCurrentForecast{ 

    public class Temperature
    {
        public Metric Metric { get; set; }
        public Imperial Imperial { get; set; }
    }

}