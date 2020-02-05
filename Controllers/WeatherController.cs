using Microsoft.AspNetCore.Mvc;
using WeatherSystem.ViewModels;
using WeatherSystem.Models;

namespace WeatherSystem.Controllers
{
    public class WeatherController : Controller
    {
        private readonly ICityService _cityService;
        public WeatherController(ICityService cityService)
        {
            _cityService = cityService;
        }

        public IActionResult Index(WeatherVM weathervm)
        {
            weathervm.LocalCity = _cityService.CheckLocalWeather().LocalCity;
            return View(weathervm);
        }

        public IActionResult CheckWeather(WeatherVM weathervm)
        {
            try
            {
                weathervm.LocalCity = _cityService.CheckLocalWeather().LocalCity;
                weathervm.AskedCity = _cityService.CheckWeather(weathervm);
            }
            catch
            {
                ModelState.AddModelError("CityError","Invalid city name!");
                weathervm.AskedCity.Name = null;
                return View("Index",weathervm);
            }
            return View("Index",weathervm);
        }
    }
}