﻿using Newtonsoft.Json;
using System.Diagnostics;
using WeatherAPP.APIClient.Models;

namespace WeatherAPP.APIClient
{
    public class AccuWeatherClient
    {
        private const string API_KEY = "LBSxEUi5eipqM5RXrbxbAJLIVssHYumD";
        private const string LANGUAGE_CODE = "pl";
        private const string BASE_URL = "http://dataservice.accuweather.com";
        private const string SEARCH_ENDPOINT = $"{BASE_URL}/locations/v1/cities/search?apikey={{0}}&q={{1}}&language={{2}}&details=true";
        private const string ALERTS_ENDPOINT = $"{BASE_URL}/alarms/v1/1day/{{0}}?apikey={{1}}&language={{2}}";
        private const string CURRENT_FORECAST_ENDPOINT = $"{BASE_URL}/currentconditions/v1/{{0}}?apikey={{1}}&language={{2}}&metric=true&details=true";
        private const string INDICES_ENDPOINT = $"{BASE_URL}/indices/v1/daily/1day/{{0}}?apikey={{1}}&language={{2}}&details=true";
        private const string FIVE_DAY_FORECAST_ENDPOINT = $"{BASE_URL}/forecasts/v1/daily/5day/{{0}}?apikey={{1}}&language={{2}}&metric=true&details=true";
        private const string HISTORICAL_FORECAST_ENDPOINT = $"{BASE_URL}/currentconditions/v1/{{0}}/historical/24?apikey={{1}}&language={{2}}&details=true";

        public AccuWeatherClient()
        {
        }

        public async Task<City[]> GetCities(string city)
        {
            string request = string.Format(SEARCH_ENDPOINT, API_KEY, city, LANGUAGE_CODE);
            using (HttpClient client = new HttpClient())
            {
                string response = await client.GetStringAsync(request);

                return JsonConvert.DeserializeObject<City[]>(response) ?? new City[0];
            }
        }

        public async Task GetAlerts(City city)
        {
            string request = string.Format(ALERTS_ENDPOINT, city.Key, API_KEY, LANGUAGE_CODE);
            using (HttpClient client = new HttpClient())
            {
                string response = await client.GetStringAsync(request);

                Debug.WriteLine(response);
            }
        }

        public async Task<CurrentForecast?> GetCurrentForecast(City city)
        {
            string request = string.Format(CURRENT_FORECAST_ENDPOINT, city.Key, API_KEY, LANGUAGE_CODE);
            using (HttpClient client = new HttpClient())
            {
                string response = await client.GetStringAsync(request);

                CurrentForecast[]? array = JsonConvert.DeserializeObject<CurrentForecast[]>(response);

                return array is null ? null : array.FirstOrDefault();
            }
        }

        public async Task GetIndices(City city)
        { 
            string request = string.Format(INDICES_ENDPOINT, city.Key, API_KEY, LANGUAGE_CODE);
            using (HttpClient client = new HttpClient())
            {
                string response = await client.GetStringAsync(request);

                Debug.WriteLine(response);
            }
        }

        public async Task Get5DayForecast(City city)
        {
            string request = string.Format(FIVE_DAY_FORECAST_ENDPOINT, city.Key, API_KEY, LANGUAGE_CODE);
            using (HttpClient client = new HttpClient())
            {
                string response = await client.GetStringAsync(request);

                Debug.WriteLine(response);
            }
        }

        public async Task GetHistorical24hForecast(City city)
        {
            string request = string.Format(HISTORICAL_FORECAST_ENDPOINT, city.Key, API_KEY, LANGUAGE_CODE);
            using (HttpClient client = new HttpClient())
            {
                string response = await client.GetStringAsync(request);

                Debug.WriteLine(response);
            }
        }
    }
}
