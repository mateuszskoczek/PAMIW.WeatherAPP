using System.Collections.Generic; 
namespace WeatherAPP.APIClient.Models.GetIndices
{ 

    public class Indices
    {
        public Headline Headline { get; set; }
        public List<DailyForecast> DailyForecasts { get; set; }
    }

}