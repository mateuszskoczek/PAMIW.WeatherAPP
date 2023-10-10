using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Dynamic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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
    }
}
