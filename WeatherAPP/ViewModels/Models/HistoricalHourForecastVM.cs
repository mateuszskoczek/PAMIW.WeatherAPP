using CommunityToolkit.Mvvm.ComponentModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WeatherAPP.Services.AccuWeather.Models.GetHistoricalForecast;

namespace WeatherAPP.ViewModels.Models
{
    public class HistoricalHourForecastVM : ObservableObject
    {
        #region FIELDS

        private HistoricalForecast _hourForecast;

        #endregion



        #region PROPERTIES

        public DateTime Date
        {
            get => _hourForecast.LocalObservationDateTime;
            set => SetProperty(_hourForecast.LocalObservationDateTime, value, _hourForecast, (model, value) => model.LocalObservationDateTime = value);
        }
        public double TemperatureValue
        {
            get => _hourForecast.Temperature.Metric.Value;
            set => SetProperty(_hourForecast.Temperature.Metric.Value, value, _hourForecast.Temperature.Metric, (model, value) => model.Value = value);
        }
        public string TemperatureUnit
        {
            get => _hourForecast.Temperature.Metric.Unit;
            set => SetProperty(_hourForecast.Temperature.Metric.Unit, value, _hourForecast.Temperature.Metric, (model, value) => model.Unit = value);
        }

        #endregion



        #region CONSTRUCTORS

        public HistoricalHourForecastVM(HistoricalForecast hourForecast)
        {
            _hourForecast = hourForecast;
        }

        #endregion
    }
}
