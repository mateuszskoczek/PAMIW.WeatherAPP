using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using WeatherAPP.APIClient;
using WeatherAPP.APIClient.Models;
using WeatherAPP.APIClient.Models.GetCities;
using WeatherAPP.APIClient.Models.GetCurrentForecast;
using WeatherAPP.APIClient.Models.GetHistorical24hForecast;
using WeatherAPP.APIClient.Models.GetIndices;

namespace WeatherAPP
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private async void Button_Click(object sender, RoutedEventArgs e)
        {

            AccuWeatherClient client = new AccuWeatherClient();
            City[] cities = new City[0];
            try
            {
                cities = await client.GetCities(City.Text);
            }
            catch (HttpRequestException ex)
            {
                MessageBox.Show($"Nie można pobrać informacji o podanym mieście\n{ex.Message}", "Błąd", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }
            City? city = cities.FirstOrDefault();
            if (city is null)
            {
                MessageBox.Show("Nie znaleziono lokalizacji o podanej nazwie", "Błąd", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }

            List<Task> tasks = new List<Task>();

            Task<CurrentForecast?> forecastTask = client.GetCurrentForecast(city);
            tasks.Add(forecastTask);

            Task<int> alertsTask = client.GetAlerts(city);
            tasks.Add(alertsTask);

            Task<Indices[]> indicesTask = client.GetIndices(city);
            tasks.Add(indicesTask);

            Task<FiveDayForecast?> fiveDayForecastTask = client.Get5DayForecast(city);
            tasks.Add(fiveDayForecastTask);

            Task<Historical24hForecast?> historicalForecastTask = client.GetHistorical24hForecast(city);
            tasks.Add(historicalForecastTask);

            await Task.WhenAll(tasks);

            if (forecastTask.Result is null)
            {
                MessageBox.Show("Nie udało się pobrać informacji o aktualnej pogodzie", "Błąd", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }

            CityTB.Text = $"{city.LocalizedName} {DateTime.Now:dd.MM.yyyy hh:mm:ss}";

            APIClient.Models.GetCurrentForecast.Metric? temp = forecastTask.Result.Temperature.Metric;
            TemperatureTB.Text = $"{temp.Value} °{temp.Unit}";

            APIClient.Models.GetCurrentForecast.Wind wind = forecastTask.Result.Wind;
            WindTB.Text = $"{wind.Speed.Metric.Value} {wind.Speed.Metric.Unit} (kierunek {wind.Direction.Degrees}°)";

            CloudTB.Text = forecastTask.Result.CloudCover.ToString();
            
            UVIndexTB.Text = forecastTask.Result.UVIndex.ToString();

            APIClient.Models.GetCurrentForecast.Metric press = forecastTask.Result.Pressure.Metric;
            PressureTB.Text = $"{press.Value} {press.Unit}";

            AlertsTB.Text = alertsTask.Result.ToString();

            Temp5dTB.Text = fiveDayForecastTask.Result.Value.ToString();

            APIClient.Models.GetHistorical24hForecast.Metric? temp24h = historicalForecastTask.Result.Temperature.Metric;
            Temp24hTB.Text = $"{temp24h.Value} °{temp24h.Unit}";

            IndicesTB.Text = indicesTask.Result.Length.ToString();
        }
    }
}
