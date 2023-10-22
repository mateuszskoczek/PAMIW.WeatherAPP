using System; 
namespace WeatherAPP.Services.AccuWeather.Models.GetCurrentForecast{ 

    public class CurrentForecast
    {
        public DateTime LocalObservationDateTime { get; set; }
        public int EpochTime { get; set; }
        public string WeatherText { get; set; }
        public int WeatherIcon { get; set; }
        public bool HasPrecipitation { get; set; }
        public object PrecipitationType { get; set; }
        public bool IsDayTime { get; set; }
        public Temperature Temperature { get; set; }
        public RealFeelTemperature RealFeelTemperature { get; set; }
        public RealFeelTemperatureShade RealFeelTemperatureShade { get; set; }
        public int RelativeHumidity { get; set; }
        public int IndoorRelativeHumidity { get; set; }
        public DewPoint DewPoint { get; set; }
        public Wind Wind { get; set; }
        public WindGust WindGust { get; set; }
        public int UVIndex { get; set; }
        public string UVIndexText { get; set; }
        public Visibility Visibility { get; set; }
        public string ObstructionsToVisibility { get; set; }
        public int CloudCover { get; set; }
        public Ceiling Ceiling { get; set; }
        public Pressure Pressure { get; set; }
        public PressureTendency PressureTendency { get; set; }
        public Past24HourTemperatureDeparture Past24HourTemperatureDeparture { get; set; }
        public ApparentTemperature ApparentTemperature { get; set; }
        public WindChillTemperature WindChillTemperature { get; set; }
        public WetBulbTemperature WetBulbTemperature { get; set; }
        public Precip1hr Precip1hr { get; set; }
        public PrecipitationSummary PrecipitationSummary { get; set; }
        public TemperatureSummary TemperatureSummary { get; set; }
        public string MobileLink { get; set; }
        public string Link { get; set; }
    }

}