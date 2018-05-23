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
            //string key = "453fcf7ce64d8bd77e4013b8c6c5f496";
            //string queryString = "http://api.openweathermap.org/data/2.5/weather?zip=" + "57650" + ",fr&appid=" + key + "&units=metric";

            string latitude = "49.3559";
            string longitude = "5.99638";
            string auth = "BR9RRgR6V3UFKFptUCYHLlkxVGEOeAgvC3dXNABlVyoAa1IzAGABZ1A%2BUC1XeFdhUH0AYwkyAzMHbFIqDnxUNQVvUT0Eb1cwBWpaP1B%2FByxZd1Q1Di4ILwtpVzkAblcqAGpSNwB9AWBQOVAsV2VXYVBrAH8JKQM6B2FSNw5lVD4FblE1BG5XMQVoWidQfwc2WThUNA4yCGULaVc0ADhXNQBqUj4AawFlUD9QLFdvV2BQYwBiCTIDMgdnUjQOfFQoBR9RRgR6V3UFKFptUCYHLlk%2FVGoOZQ%3D%3D";
            string queryString = "http://www.infoclimat.fr/public-api/gfs/json?_ll="
                + latitude+","+longitude+"&_auth="
                + auth + "&_c=00e0a65f995e0f9afe937cba34c8c6f3";

            dynamic results = await DataService.getDataFromService(queryString).ConfigureAwait(false);

            if (results["request_state"].Value != null)
            {
                
                Weather weather = new Weather();
                string Temperature = (string)results[CalculCreneau(DateTime.Now.ToShortDateString(), DateTime.Now.ToLongTimeString())]["temperature"]["sol"];

                //float TempX = float.Parse(Temperature);

                //Temperature -= 273.15;
                //Console.WriteLine(Temperature);

                //weather.Temperature = (string)results[CalculCreneau(DateTime.Now.ToShortDateString(), DateTime.Now.ToLongTimeString())]["temperature"]["sol"] + " °C";
                weather.Temperature = Temperature.ToString() + " °K";

                /*weather.Title = (string)results["name"];
                weather.Temperature = (string)results["main"]["temp"] + " °C";
                weather.Wind = (string)results["wind"]["speed"] + " mph";
                weather.Humidity = (string)results["main"]["humidity"] + " %";
                weather.Visibility = (string)results["weather"][0]["main"];

                DateTime time = new System.DateTime(1970, 1, 1, 0, 0, 0, 0);
                DateTime sunrise = time.AddSeconds((double)results["sys"]["sunrise"]);
                DateTime sunset = time.AddSeconds((double)results["sys"]["sunset"]);
                weather.Sunrise = sunrise.ToString() + " UTC";
                weather.Sunset = sunset.ToString() + " UTC";*/
                return weather;
            }
            
            else
            {
                return null;
            }
        }

        private static string CalculCreneau(string date, string heure)
        {
            if (Convert.ToDateTime(heure) >= DateTime.Parse("02:00:00") && Convert.ToDateTime(heure) <= DateTime.Parse("04:59:59"))
            {
                return Convert.ToDateTime(date).ToString("yyyy-MM-dd") + " 02:00:00";
            }
            else if (Convert.ToDateTime(heure) >= DateTime.Parse("05:00:00") && Convert.ToDateTime(heure) <= DateTime.Parse("07:59:59"))
            {
                return Convert.ToDateTime(date).ToString("yyyy-MM-dd") + " 05:00:00";
            }
            else if (Convert.ToDateTime(heure) >= DateTime.Parse("08:00:00") && Convert.ToDateTime(heure) <= DateTime.Parse("10:59:59"))
            {
                return Convert.ToDateTime(date).ToString("yyyy-MM-dd") + " 08:00:00";
            }
            else if (Convert.ToDateTime(heure) >= DateTime.Parse("11:00:00") && Convert.ToDateTime(heure) <= DateTime.Parse("13:59:59"))
            {
                return Convert.ToDateTime(date).ToString("yyyy-MM-dd") + " 11:00:00";
            }
            else if (Convert.ToDateTime(heure) >= DateTime.Parse("14:00:00") && Convert.ToDateTime(heure) <= DateTime.Parse("16:59:59"))
            {
                return Convert.ToDateTime(date).ToString("yyyy-MM-dd") + " 14:00:00";
            }
            else if (Convert.ToDateTime(heure) >= DateTime.Parse("17:00:00") && Convert.ToDateTime(heure) <= DateTime.Parse("19:59:59"))
            {
                return Convert.ToDateTime(date).ToString("yyyy-MM-dd") + " 17:00:00";
            }
            else if (Convert.ToDateTime(heure) >= DateTime.Parse("20:00:00") && Convert.ToDateTime(heure) <= DateTime.Parse("22:59:59"))
            {
                return Convert.ToDateTime(date).ToString("yyyy-MM-dd") + " 20:00:00";
            }
            else if (Convert.ToDateTime(heure) >= DateTime.Parse("23:00:00") && Convert.ToDateTime(heure) <= DateTime.Parse("23:59:59"))
            {
                return Convert.ToDateTime(date).ToString("yyyy-MM-dd") + " 23:00:00";
            }
            else if (Convert.ToDateTime(heure) >= DateTime.Parse("00:00:00") && Convert.ToDateTime(heure) <= DateTime.Parse("01:59:59"))
            {
                return Convert.ToDateTime(date).AddDays(-1).ToString("yyyy-MM-dd") + " 23:00:00";
            }
            else
            {
                return string.Empty;
            }
        }
    }
}
