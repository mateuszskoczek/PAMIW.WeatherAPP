using CommunityToolkit.Mvvm.ComponentModel;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WeatherAPP.Services.AccuWeather.Models.GetFiveDayForecast;

namespace WeatherAPP.ViewModels.Models
{
    public class FiveDayDailyForecastVM : ObservableObject
    {
        #region FIELDS

        private DailyForecast _dailyForecast;

        #endregion



        #region PROPERTIES

        public DateTime Date
        {
            get => _dailyForecast.Date;
            set => SetProperty(_dailyForecast.Date, value, _dailyForecast, (model, value) => model.Date = value);
        }
        public double TemperatureMinValue
        {
            get => _dailyForecast.Temperature.Minimum.Value;
            set => SetProperty(_dailyForecast.Temperature.Minimum.Value, value, _dailyForecast.Temperature.Minimum, (model, value) => model.Value = value);
        }
        public double TemperatureMaxValue
        {
            get => _dailyForecast.Temperature.Maximum.Value;
            set => SetProperty(_dailyForecast.Temperature.Maximum.Value, value, _dailyForecast.Temperature.Maximum, (model, value) => model.Value = value);
        }
        public string TemperatureUnit
        {
            get => _dailyForecast.Temperature.Minimum.Unit;
            set => SetProperty(_dailyForecast.Temperature.Minimum.Unit, value, _dailyForecast.Temperature.Minimum, (model, value) => model.Unit = value);
        }

        #endregion



        #region CONSTRUCTORS

        public FiveDayDailyForecastVM(DailyForecast dailyForecast)
        {
            _dailyForecast = dailyForecast;
        }

        #endregion
    }
}
