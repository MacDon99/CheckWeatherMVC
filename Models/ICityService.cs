using WeatherSystem.ViewModels;

namespace WeatherSystem.Models
{
    public interface ICityService
    {
        City Check(string city);
        WeatherVM CheckLocalWeather();
        City CheckWeather(WeatherVM weathervm);
    }
}
