using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using WeatherAPP.Services.AccuWeather.Models;
using WeatherAPP.Services.AccuWeather.Models.GetCities;
using WeatherAPP.Services.AccuWeather.Models.GetCurrentForecast;
using WeatherAPP.Services.AccuWeather.Models.GetFiveDayForecast;
using WeatherAPP.Services.AccuWeather.Models.GetHistoricalForecast;
using WeatherAPP.Services.AccuWeather.Models.GetIndices;
using WeatherAPP.Services.AccuWeather.Models.GetWeatherAlarms;
using WeatherAPP.ViewModels.Models;

namespace WeatherAPP.ViewModels.Views
{
    public partial class MainWindowVM : ObservableObject
    {
        #region FIELDS

        private IAccuWeatherService _accuWeatherService;

        private CityVM _selectedCity;

        [ObservableProperty]
        private string _city;

        [ObservableProperty]
        private string _refreshDateTime;

        [ObservableProperty]
        private CurrentForecastVM _currentForecast;

        [ObservableProperty]
        private FiveDayForecastVM _fiveDayForecast;

        [ObservableProperty]
        private HistoricalForecastVM _historicalForecast;

        [ObservableProperty]
        private IndicesVM _indices;

        [ObservableProperty]
        private WeatherAlarmsVM _weatherAlarms;

        #endregion



        #region PROPERTIES

        public CityVM SelectedCity
        {
            get => _selectedCity;
            set
            {
                SetProperty(ref _selectedCity, value);
                RefreshData();
            }
        }

        public ObservableCollection<CityVM> Cities { get; protected set; }

        #endregion



        #region CONSTRUCTORS

        public MainWindowVM(IAccuWeatherService accuWeatherService)
        {
            _accuWeatherService = accuWeatherService;

            Cities = new ObservableCollection<CityVM>();
        }

        #endregion



        #region PUBLIC METHODS

        [RelayCommand]
        public async Task SearchCity()
        {
            IEnumerable<City> cities = await _accuWeatherService.GetCities(City);
            Cities.Clear();
            foreach (City city in cities)
            {
                Cities.Add(new CityVM(city));
            }
        }

        public async void RefreshData()
        {
            if (SelectedCity is not null)
            {
                CurrentForecast = null;

                List<Task> tasks = new List<Task>();

                Task<CurrentForecast?> currentForecastTask = _accuWeatherService.GetCurrentForecast(_selectedCity.Model);
                tasks.Add(currentForecastTask);

                Task<FiveDayForecast?> fiveDayForecastTask = _accuWeatherService.GetFiveDayForecast(_selectedCity.Model);
                tasks.Add(fiveDayForecastTask);

                Task<IEnumerable<HistoricalForecast>> historicalForecastTask = _accuWeatherService.GetHistoricalForecast(_selectedCity.Model);
                tasks.Add(historicalForecastTask);

                Task<IEnumerable<Indices>> indicesTask = _accuWeatherService.GetIndices(_selectedCity.Model);
                tasks.Add(indicesTask);

                Task<IEnumerable<WeatherAlarms>> weatherAlarmsTask = _accuWeatherService.GetWeatherAlarms(_selectedCity.Model);
                tasks.Add(weatherAlarmsTask);

                await Task.WhenAll(tasks);

                List<string> errors = new List<string>();

                if (currentForecastTask.Result is null)
                {
                    errors.Add("Aktualna pogoda");
                }
                else
                {
                    CurrentForecast = new CurrentForecastVM(currentForecastTask.Result);
                }

                if (fiveDayForecastTask.Result is null)
                {
                    errors.Add("Prognoza 5-dniowa");
                }
                else
                {
                    FiveDayForecast = new FiveDayForecastVM(fiveDayForecastTask.Result);
                }

                if (!historicalForecastTask.Result.Any())
                {
                    errors.Add("Prognoza historyczna");
                }
                else
                {
                    HistoricalForecast = new HistoricalForecastVM(historicalForecastTask.Result);
                }

                if (!indicesTask.Result.Any())
                {
                    errors.Add("Indeksy");
                }
                else
                {
                    Indices = new IndicesVM(indicesTask.Result);
                }

                WeatherAlarms = new WeatherAlarmsVM(weatherAlarmsTask.Result);

                if (errors.Count > 0)
                {
                    MessageBox.Show($"Nie udało się pobrać następujących sekcji:\n{string.Join('\n', errors)}", "Błąd!", MessageBoxButton.OK, MessageBoxImage.Error);
                }
                
                if (errors.Count != tasks.Count)
                {
                    RefreshDateTime = DateTime.Now.ToString("dd.MM.yyyy HH:mm");
                }
            }
        }

        #endregion
    }
}
