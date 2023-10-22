using CommunityToolkit.Mvvm.ComponentModel;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WeatherAPP.Services.AccuWeather.Models.GetHistoricalForecast;
using WeatherAPP.Services.AccuWeather.Models.GetIndices;

namespace WeatherAPP.ViewModels.Models
{
    public class IndicesVM : ObservableObject
    {
        #region FIELDS

        private IEnumerable<Indices> _indices;

        #endregion



        #region PROPERTIES

        public ObservableCollection<IndicesIndexVM> Indices { get; set; }

        #endregion



        #region CONSTRUCTORS

        public IndicesVM(IEnumerable<Indices> indices)
        {
            _indices = indices;

            Indices = new ObservableCollection<IndicesIndexVM>();

            foreach (Indices index in _indices)
            {
                Indices.Add(new IndicesIndexVM(index));
            }
        }

        #endregion
    }
}
