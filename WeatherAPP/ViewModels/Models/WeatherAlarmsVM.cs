using CommunityToolkit.Mvvm.ComponentModel;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WeatherAPP.Services.AccuWeather.Models.GetIndices;
using WeatherAPP.Services.AccuWeather.Models.GetWeatherAlarms;

namespace WeatherAPP.ViewModels.Models
{
    public class WeatherAlarmsVM : ObservableObject
    {
        #region FIELDS

        private IEnumerable<WeatherAlarms> _weatherAlarms;

        #endregion



        #region PROPERTIES

        public int Count
        {
            get
            {
                int count = 0;
                foreach (WeatherAlarms alarm in _weatherAlarms)
                {
                    count += alarm.Alarms.Count;
                }
                return count;
            }
        }

        #endregion



        #region CONSTRUCTORS

        public WeatherAlarmsVM(IEnumerable<WeatherAlarms> weatherAlarms)
        {
            _weatherAlarms = weatherAlarms;
        }

        #endregion
    }
}
