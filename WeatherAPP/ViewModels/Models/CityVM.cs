using CommunityToolkit.Mvvm.ComponentModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WeatherAPP.Services.AccuWeather.Models.GetCities;

namespace WeatherAPP.ViewModels.Models
{
    public class CityVM : ObservableObject
    {
        #region FIELDS

        private City _city;

        #endregion



        #region PROPERTIES

        public City Model => _city;

        public string Name
        {
            get => _city.LocalizedName;
            set => SetProperty(_city.LocalizedName, value, _city, (model, value) => model.LocalizedName = value);
        }

        public string Region
        {
            get => _city.AdministrativeArea.LocalizedName;
            set => SetProperty(_city.AdministrativeArea.LocalizedName, value, _city.AdministrativeArea, (model, value) => model.LocalizedName = value);
        }

        public string Country
        {
            get => _city.Country.LocalizedName;
            set => SetProperty(_city.Country.LocalizedName, value, _city.Country, (model, value) => model.LocalizedName = value);
        }

        #endregion



        #region CONSTRUCTORS

        public CityVM(City city)
        {
            _city = city;
        }

        #endregion
    }
}
