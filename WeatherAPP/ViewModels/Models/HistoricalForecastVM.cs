using CommunityToolkit.Mvvm.ComponentModel;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WeatherAPP.Services.AccuWeather.Models.GetFiveDayForecast;
using WeatherAPP.Services.AccuWeather.Models.GetHistoricalForecast;

namespace WeatherAPP.ViewModels.Models
{
    public class HistoricalForecastVM : ObservableObject
    {
        #region FIELDS

        private IEnumerable<HistoricalForecast> _historicalForecast;

        #endregion



        #region PROPERTIES

        public ObservableCollection<HistoricalHourForecastVM> Forecasts { get; set; }

        #endregion



        #region CONSTRUCTORS

        public HistoricalForecastVM(IEnumerable<HistoricalForecast> historicalForecast)
        {
            _historicalForecast = historicalForecast;

            Forecasts = new ObservableCollection<HistoricalHourForecastVM>();

            foreach (HistoricalForecast forecast in _historicalForecast)
            {
                Forecasts.Add(new HistoricalHourForecastVM(forecast));
            }
        }

        #endregion
    }
}
