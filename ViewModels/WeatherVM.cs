using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WeatherSystem.Models;

namespace WeatherSystem.ViewModels
{
    public class WeatherVM
    {
        public City LocalCity { get; set; }
        public City AskedCity { get; set; }

        public WeatherVM()
        {
            LocalCity = new City();
            AskedCity = new City();
        }
    }
}
