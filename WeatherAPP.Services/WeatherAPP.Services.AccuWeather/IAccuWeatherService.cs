using WeatherAPP.Services.AccuWeather.Models.GetCities;
using WeatherAPP.Services.AccuWeather.Models.GetCurrentForecast;
using WeatherAPP.Services.AccuWeather.Models.GetFiveDayForecast;
using WeatherAPP.Services.AccuWeather.Models.GetHistoricalForecast;
using WeatherAPP.Services.AccuWeather.Models.GetIndices;
using WeatherAPP.Services.AccuWeather.Models.GetWeatherAlarms;

namespace WeatherAPP.Services.AccuWeather.Models
{
    public interface IAccuWeatherService
    {
        Task<IEnumerable<City>> GetCities(string city);
        Task<CurrentForecast?> GetCurrentForecast(City city);
        Task<FiveDayForecast?> GetFiveDayForecast(City city);
        Task<IEnumerable<HistoricalForecast>> GetHistoricalForecast(City city);
        Task<IEnumerable<Indices>> GetIndices(City city);
        Task<IEnumerable<WeatherAlarms>> GetWeatherAlarms(City city);
    }
}