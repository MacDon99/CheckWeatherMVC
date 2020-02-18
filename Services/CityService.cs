using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using WeatherSystem.ApiModels;
using WeatherSystem.ViewModels;

namespace WeatherSystem.Models
{
    public class CityService : ICityService
    {
        public City Check(string city)
        {
            City CityToPass = new City();
            using (WebClient client = new WebClient())
            {
                string WeatherApiString = $"http://api.openweathermap.org/data/2.5/forecast?q={city}&APPID=7e4281bbf4367371da55bff9b38ccea8";

                string json = client.DownloadString(WeatherApiString);
                var WeatherApiInfo = JsonConvert.DeserializeObject<WeatherInfo>(json);

                double temp = 0;
                foreach (var item in WeatherApiInfo.List)
                {
                    temp += item.main.temp;
                }

                temp = temp / WeatherApiInfo.List.Count;
                temp -= 273.15;

                CityToPass.Name = city;
                CityToPass.Temperature = Math.Round(temp, 2, MidpointRounding.ToEven);
            };
            
            return CityToPass;
        }

        public WeatherVM CheckLocalWeather()
        {
            WeatherVM weathervm = new WeatherVM();

            using (WebClient klient = new WebClient())
            {
                
                string json = klient.DownloadString("https://api.ipgeolocation.io/getip");
                var GetIpApi = JsonConvert.DeserializeObject<GetIp>(json);
                string json2 = klient.DownloadString($"https://api.ipgeolocation.io/ipgeo?apiKey=05061dc94ff04170b61d064708615c71&ip={GetIpApi.ip}");
                var GetLocApi = JsonConvert.DeserializeObject<GetLoc>(json2);
                weathervm.LocalCity = Check(GetLocApi.city);
            };
            return weathervm;
        }

        public City CheckWeather(WeatherVM weather)
        {
            City City = new City();
            City = Check(weather.AskedCity.Name);

            return City;
        }

    }
}
