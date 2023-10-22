using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WeatherAPP.Services.AccuWeather.Models.GetCities;
using WeatherAPP.Services.AccuWeather.Models.GetCurrentForecast;
using WeatherAPP.Services.AccuWeather.Models.GetFiveDayForecast;
using WeatherAPP.Services.AccuWeather.Models.GetHistoricalForecast;
using WeatherAPP.Services.AccuWeather.Models.GetIndices;
using WeatherAPP.Services.AccuWeather.Models.GetWeatherAlarms;

namespace WeatherAPP.Services.AccuWeather.Models
{
    public class AccuWeatherService : IAccuWeatherService
    {
        #region FIELDS

        private AccuWeatherConfiguration _configuration;

        #endregion



        #region CONSTRUCTORS

        public AccuWeatherService(AccuWeatherConfiguration configuration)
        {
            _configuration = configuration;
        }

        #endregion



        #region PUBLIC METHODS

        public async Task<IEnumerable<City>> GetCities(string city)
        {
            string request = string.Format(_configuration.CitySearchEndpoint, _configuration.BaseUrl, _configuration.ApiKey, city, _configuration.LanguageCode);
            using (HttpClient client = new HttpClient())
            {
                string response = await client.GetStringAsync(request);

                return JsonConvert.DeserializeObject<City[]>(response) ?? new City[0];
            }
        }

        public async Task<CurrentForecast?> GetCurrentForecast(City city)
        {
            string request = string.Format(_configuration.CurrentForecastEndpoint, _configuration.BaseUrl, city.Key, _configuration.ApiKey, _configuration.LanguageCode);
            using (HttpClient client = new HttpClient())
            {
                string response = await client.GetStringAsync(request);

                CurrentForecast[]? array = JsonConvert.DeserializeObject<CurrentForecast[]>(response);

                return array?.FirstOrDefault();
            }
        }

        public async Task<FiveDayForecast?> GetFiveDayForecast(City city)
        {
            string request = string.Format(_configuration.FiveDayForecastEndpoint, _configuration.BaseUrl, city.Key, _configuration.ApiKey, _configuration.LanguageCode);
            using (HttpClient client = new HttpClient())
            {
                string response = await client.GetStringAsync(request);

                return JsonConvert.DeserializeObject<FiveDayForecast>(response);
            }
        }

        public async Task<IEnumerable<HistoricalForecast>> GetHistoricalForecast(City city)
        {
            string request = string.Format(_configuration.HistoricalForecastEndpoint, _configuration.BaseUrl, city.Key, _configuration.ApiKey, _configuration.LanguageCode);
            using (HttpClient client = new HttpClient())
            {
                string response = await client.GetStringAsync(request);

                HistoricalForecast[]? array = JsonConvert.DeserializeObject<HistoricalForecast[]>(response);

                return array is null ? Array.Empty<HistoricalForecast>() : array;
            }
        }

        public async Task<IEnumerable<Indices>> GetIndices(City city)
        {
            string request = string.Format(_configuration.IndicesEndpoint, _configuration.BaseUrl, city.Key, _configuration.ApiKey, _configuration.LanguageCode);
            using (HttpClient client = new HttpClient())
            {
                string response = await client.GetStringAsync(request);

                return JsonConvert.DeserializeObject<Indices[]>(response) ?? Array.Empty<Indices>();
            }
        }

        public async Task<IEnumerable<WeatherAlarms>> GetWeatherAlarms(City city)
        {
            string request = string.Format(_configuration.WeatherAlarmsEndpoint, _configuration.BaseUrl, city.Key, _configuration.ApiKey, _configuration.LanguageCode);
            using (HttpClient client = new HttpClient())
            {
                string response = await client.GetStringAsync(request);

                WeatherAlarms[]? array = JsonConvert.DeserializeObject<WeatherAlarms[]>(response);

                return array is null ? Array.Empty<WeatherAlarms>() : array;
            }
        }

        #endregion
    }
}
