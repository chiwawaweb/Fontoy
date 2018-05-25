using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace FontoyXamarin
{
    public class CoreMeteo
    {
        public static async Task<Meteo> GetMeteo(DateTime dateMeteo)
        {
            /* Calcul du créneau */
            string creneauMeteoNow = CalculCreneau(dateMeteo.ToShortDateString(), dateMeteo.ToLongTimeString());
            string creneauMeteoH6 = CalculCreneau(dateMeteo.AddHours(6).ToShortDateString(), dateMeteo.AddHours(6).ToLongTimeString());
            string creneauMeteoH12 = CalculCreneau(dateMeteo.AddHours(12).ToShortDateString(), dateMeteo.AddHours(12).ToLongTimeString());

            string latitude = "49.3559";
            string longitude = "5.99638";
            string auth = "BR9RRgR6V3UFKFptUCYHLlkxVGEOeAgvC3dXNABlVyoAa1IzAGABZ1A%2BUC1XeFdhUH0AYwkyAzMHbFIqDnxUNQVvUT0Eb1cwBWpaP1B%2FByxZd1Q1Di4ILwtpVzkAblcqAGpSNwB9AWBQOVAsV2VXYVBrAH8JKQM6B2FSNw5lVD4FblE1BG5XMQVoWidQfwc2WThUNA4yCGULaVc0ADhXNQBqUj4AawFlUD9QLFdvV2BQYwBiCTIDMgdnUjQOfFQoBR9RRgR6V3UFKFptUCYHLlk%2FVGoOZQ%3D%3D";
            //string queryString = "http://www.infoclimat.fr/public-api/gfs/json?_ll="
              //  + latitude+","+longitude+"&_auth="
              //  + auth + "&_c=00e0a65f995e0f9afe937cba34c8c6f3";

            string queryString = "https://www.prevision-meteo.ch/services/json/fontoy";

            Console.WriteLine("===xx====xx====xx=====");

            dynamic results = await DataService.getDataFromService(queryString).ConfigureAwait(false);

            Console.WriteLine("****** " + (string)results["city_info"]["name"]);

            if ((string)results["city_info"]["name"]=="Fontoy")
            {
                Meteo meteo = new Meteo();

                /* Récupération des données JSON */
                Console.WriteLine((string)results["current_condition"]["condition_key"]);
                /*
                int jsonPressionNow = (int)results[creneauMeteoNow]["pression"]["niveau_de_la_mer"];
                int jsonVentDirectionNow = (int)results[creneauMeteoNow]["vent_direction"]["10m"];
                double jsonVentMoyenVitesse = (double)results[creneauMeteoNow]["vent_moyen"]["10m"];
                double jsonVentRafalesVitesse = (double)results[creneauMeteoNow]["vent_rafales"]["10m"];
                int jsonHumiditeNow = (int)results[creneauMeteoNow]["humidite"]["2m"];
                */

                /* Conversion des données */

                /* Meteo Now */
                /*int pressionNow = jsonPressionNow / 100;

                double temperatureKelvinNow = double.Parse((string)results[creneauMeteoNow]["temperature"]["sol"], 
                    System.Globalization.CultureInfo.InvariantCulture);
                double temperatureCelciusNow = temperatureKelvinNow - 273.15;

                meteo.TemperatureNow = " " + temperatureCelciusNow.ToString("0") + " °C";
                meteo.PressionNow = pressionNow.ToString() + " hPa";
                meteo.VentMoyenVitesseNow = jsonVentMoyenVitesse + " km/h";
                meteo.VentRafalesVitesseNow = jsonVentRafalesVitesse + " km/h";
                meteo.VentDirectionNow = CalculVentDirection(jsonVentDirectionNow).ToString();
                meteo.HumiditeNow = jsonHumiditeNow + " %";
                meteo.NebulositeNow = (string)results[creneauMeteoNow]["nebulosite"]["totale"] +  " %";
                meteo.RisqueNeigeNow = (string)results[creneauMeteoNow]["risque_neige"];
                */

                return meteo;
            }
            
            else
            {
                /* Code de retour différent de 200 */
                Meteo meteo = new Meteo();

                return meteo;
            }
        }

        private static int CalculVentDirection(int valeurBrute)
        {
            if (valeurBrute<360)
            {
                return (valeurBrute % 360) - 180;
            }
            else if (valeurBrute>360)
            {
                return (valeurBrute % 360) + 180;
            }
            else
            {
                return 0;
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
