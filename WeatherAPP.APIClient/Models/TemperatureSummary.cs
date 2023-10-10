namespace WeatherAPP.APIClient.Models{ 

    public class TemperatureSummary
    {
        public Past6HourRange Past6HourRange { get; set; }
        public Past12HourRange Past12HourRange { get; set; }
        public Past24HourRange Past24HourRange { get; set; }
    }

}