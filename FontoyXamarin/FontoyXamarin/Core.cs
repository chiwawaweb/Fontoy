using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace FontoyXamarin
{
    public class Core
    {
        public static async Task<Weather> GetWeather()
        {
            //Sign up for a free API key at http://openweathermap.org/appid  
            string key = "453fcf7ce64d8bd77e4013b8c6c5f496";
            //string queryString = "http://www.infoclimat.fr/public-api/gfs/json?_ll=49.3559,5.99638&_auth=BR9RRgR6V3UFKFptUCYHLlkxVGEOeAgvC3dXNABlVyoAa1IzAGABZ1A%2BUC1XeFdhUH0AYwkyAzMHbFIqDnxUNQVvUT0Eb1cwBWpaP1B%2FByxZd1Q1Di4ILwtpVzkAblcqAGpSNwB9AWBQOVAsV2VXYVBrAH8JKQM6B2FSNw5lVD4FblE1BG5XMQVoWidQfwc2WThUNA4yCGULaVc0ADhXNQBqUj4AawFlUD9QLFdvV2BQYwBiCTIDMgdnUjQOfFQoBR9RRgR6V3UFKFptUCYHLlk%2FVGoOZQ%3D%3D&_c=00e0a65f995e0f9afe937cba34c8c6f3";
            string queryString = "http://api.openweathermap.org/data/2.5/weather?zip="
                + "57650" + ",fr&appid=" + key + "&units=metric";

            //Make sure developers running this sample replaced the API key
            if (key == "YOUR API KEY HERE")
            {
                throw new ArgumentException("You must obtain an API key from openweathermap.org/appid and save it in the 'key' variable.");
            }

            dynamic results = await DataService.getDataFromService(queryString).ConfigureAwait(false);

            if (results["weather"] != null)
            {
                Weather weather = new Weather();
                weather.Title = (string)results["name"];
                weather.Temperature = (string)results["main"]["temp"] + " °C";
                weather.Wind = (string)results["wind"]["speed"] + " mph";
                weather.Humidity = (string)results["main"]["humidity"] + " %";
                weather.Visibility = (string)results["weather"][0]["main"];

                DateTime time = new System.DateTime(1970, 1, 1, 0, 0, 0, 0);
                DateTime sunrise = time.AddSeconds((double)results["sys"]["sunrise"]);
                DateTime sunset = time.AddSeconds((double)results["sys"]["sunset"]);
                weather.Sunrise = sunrise.ToString() + " UTC";
                weather.Sunset = sunset.ToString() + " UTC";
                return weather;
            }
            else
            {
                return null;
            }
        }
    }
}
