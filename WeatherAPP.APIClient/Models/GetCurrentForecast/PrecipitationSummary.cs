namespace WeatherAPP.APIClient.Models.GetCurrentForecast{ 

    public class PrecipitationSummary
    {
        public Precipitation Precipitation { get; set; }
        public PastHour PastHour { get; set; }
        public Past3Hours Past3Hours { get; set; }
        public Past6Hours Past6Hours { get; set; }
        public Past9Hours Past9Hours { get; set; }
        public Past12Hours Past12Hours { get; set; }
        public Past18Hours Past18Hours { get; set; }
        public Past24Hours Past24Hours { get; set; }
    }

}