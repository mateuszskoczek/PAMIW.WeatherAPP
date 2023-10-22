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
    public class FiveDayForecastVM : ObservableObject
    {
        #region FIELDS

        private FiveDayForecast _fiveDayForecast;

        #endregion



        #region PROPERTIES

        public ObservableCollection<FiveDayDailyForecastVM> Forecasts { get; set; }

        #endregion



        #region CONSTRUCTORS

        public FiveDayForecastVM(FiveDayForecast fiveDayForecast)
        {
            _fiveDayForecast = fiveDayForecast;

            Forecasts = new ObservableCollection<FiveDayDailyForecastVM>();

            foreach (DailyForecast forecast in _fiveDayForecast.DailyForecasts)
            {
                Forecasts.Add(new FiveDayDailyForecastVM(forecast));
            }
        }

        #endregion
    }
}
