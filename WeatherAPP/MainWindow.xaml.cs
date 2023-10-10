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

            Task alertsTask = client.GetAlerts(city);
            tasks.Add(alertsTask);

            Task indicesTask = client.GetIndices(city);
            tasks.Add(indicesTask);

            Task fiveDayForecastTask = client.Get5DayForecast(city);
            tasks.Add(fiveDayForecastTask);

            Task historicalForecastTask = client.GetHistorical24hForecast(city);
            tasks.Add(historicalForecastTask);

            await Task.WhenAll(tasks);

            if (forecastTask.Result is null)
            {
                MessageBox.Show("Nie udało się pobrać informacji o aktualnej pogodzie", "Błąd", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }

            CityTB.Text = $"{city.LocalizedName} {DateTime.Now:dd.MM.yyyy hh:mm:ss}";

            Metric? temp = forecastTask.Result.Temperature.Metric;
            TemperatureTB.Text = $"{temp.Value} °{temp.Unit}";

            Wind wind = forecastTask.Result.Wind;
            WindTB.Text = $"{wind.Speed.Metric.Value} {wind.Speed.Metric.Unit} (kierunek {wind.Direction.Degrees}°)";

            CloudTB.Text = forecastTask.Result.CloudCover.ToString();
            
            UVIndexTB.Text = forecastTask.Result.UVIndex.ToString();

            Metric press = forecastTask.Result.Pressure.Metric;
            PressureTB.Text = $"{press.Value} {press.Unit}";


        }
    }
}
