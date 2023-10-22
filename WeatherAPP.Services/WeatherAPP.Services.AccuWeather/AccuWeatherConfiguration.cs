using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WeatherAPP.Services.AccuWeather.Models
{
    public class AccuWeatherConfiguration
    {
        #region PROPERTIES

        public string ApiKey { get; private set; }
        public string LanguageCode { get; private set; }
        public string BaseUrl { get; private set; }
        public string CitySearchEndpoint { get; private set; }
        public string CurrentForecastEndpoint { get; private set; }
        public string FiveDayForecastEndpoint { get; private set; }
        public string HistoricalForecastEndpoint { get; private set; }
        public string IndicesEndpoint { get; private set; }
        public string WeatherAlarmsEndpoint { get; private set; }

        #endregion



        #region CONSTRUCTORS

        public AccuWeatherConfiguration(IConfiguration configuration)
        {
            ApiKey = configuration["accuweather_apikey"];
            LanguageCode = configuration["accuweather_language_code"];
            BaseUrl = configuration["accuweather_base_url"];
            CitySearchEndpoint = configuration["accuweather_city_search_endpoint"];
            CurrentForecastEndpoint = configuration["accuweather_current_forecast_endpoint"];
            FiveDayForecastEndpoint = configuration["accuweather_five_day_forecast_endpoint"];
            HistoricalForecastEndpoint = configuration["accuweather_historical_forecast_endpoint"];
            IndicesEndpoint = configuration["accuweather_indices_endpoint"];
            WeatherAlarmsEndpoint = configuration["accuweather_weather_alarms_endpoint"];
        }

        #endregion
    }
}
