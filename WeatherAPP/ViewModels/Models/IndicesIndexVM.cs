using CommunityToolkit.Mvvm.ComponentModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WeatherAPP.Services.AccuWeather.Models.GetHistoricalForecast;
using WeatherAPP.Services.AccuWeather.Models.GetIndices;

namespace WeatherAPP.ViewModels.Models
{
    public class IndicesIndexVM : ObservableObject
    {
        #region FIELDS

        private Indices _index;

        #endregion



        #region PROPERTIES

        public string Name
        {
            get => _index.Name;
            set => SetProperty(_index.Name, value, _index, (model, value) => model.Name = value);
        }
        public string Value
        {
            get => _index.Text;
            set => SetProperty(_index.Text, value, _index, (model, value) => model.Text = value);
        }

        #endregion



        #region CONSTRUCTORS

        public IndicesIndexVM(Indices index)
        {
            _index = index;
        }

        #endregion
    }
}
