using CommunityToolkit.Mvvm.ComponentModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WeatherAPP.Services.AccuWeather.Models.GetCurrentForecast;

namespace WeatherAPP.ViewModels.Models
{
    public class CurrentForecastVM : ObservableObject
    {
        #region FIELDS

        private CurrentForecast _currentForecast;

        #endregion



        #region PROPERTIES

        public string Description
        {
            get => _currentForecast.WeatherText;
            set => SetProperty(_currentForecast.WeatherText, value, _currentForecast, (model, value) => model.WeatherText = value);
        }
        public double TemperatureValue
        {
            get => _currentForecast.Temperature.Metric.Value;
            set => SetProperty(_currentForecast.Temperature.Metric.Value, value, _currentForecast.Temperature.Metric, (model, value) => model.Value = value);
        }
        public string TemperatureUnit
        {
            get => _currentForecast.Temperature.Metric.Unit;
            set => SetProperty(_currentForecast.Temperature.Metric.Unit, value, _currentForecast.Temperature.Metric, (model, value) => model.Unit = value);
        }
        public double PressureValue
        {
            get => _currentForecast.Pressure.Metric.Value;
            set => SetProperty(_currentForecast.Pressure.Metric.Value, value, _currentForecast.Pressure.Metric, (model, value) => model.Value = value);
        }
        public string PressureUnit
        {
            get => _currentForecast.Pressure.Metric.Unit;
            set => SetProperty(_currentForecast.Pressure.Metric.Unit, value, _currentForecast.Pressure.Metric, (model, value) => model.Unit = value);
        }
        public double WindSpeedValue
        {
            get => _currentForecast.Wind.Speed.Metric.Value;
            set => SetProperty(_currentForecast.Wind.Speed.Metric.Value, value, _currentForecast.Wind.Speed.Metric, (model, value) => model.Value = value);
        }
        public string WindSpeedUnit
        {
            get => _currentForecast.Wind.Speed.Metric.Unit;
            set => SetProperty(_currentForecast.Wind.Speed.Metric.Unit, value, _currentForecast.Wind.Speed.Metric, (model, value) => model.Unit = value);
        }
        public int WindDirection
        {
            get => _currentForecast.Wind.Direction.Degrees;
            set => SetProperty(_currentForecast.Wind.Direction.Degrees, value, _currentForecast.Wind.Direction, (model, value) => model.Degrees = value);
        }
        public int UVIndex
        {
            get => _currentForecast.UVIndex;
            set => SetProperty(_currentForecast.UVIndex, value, _currentForecast, (model, value) => model.UVIndex = value);
        }

        #endregion



        #region CONSTRUCTORS

        public CurrentForecastVM(CurrentForecast currentForecast)
        {
            _currentForecast = currentForecast;
        }

        #endregion
    }
}
