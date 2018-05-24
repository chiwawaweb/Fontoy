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
            string queryString = "http://www.infoclimat.fr/public-api/gfs/json?_ll="
                + latitude+","+longitude+"&_auth="
                + auth + "&_c=00e0a65f995e0f9afe937cba34c8c6f3";

            dynamic results = await DataService.getDataFromService(queryString).ConfigureAwait(false);

            if ((Int64)results["request_state"].Value == 200)
            {
                int _ventDirectionNow;

                Meteo meteo = new Meteo();

                /* Meteo Now */
                int pressionNow = (int)results[creneauMeteoNow]["pression"]["niveau_de_la_mer"] / 100;

                double temperatureKelvinNow = double.Parse((string)results[creneauMeteoNow]["temperature"]["sol"], 
                    System.Globalization.CultureInfo.InvariantCulture);
                double temperatureCelciusNow = temperatureKelvinNow - 273.15;

                int ventDirectionNow = (int)results[creneauMeteoNow]["vent_direction"]["10m"];
                
                if (ventDirectionNow<360)
                {
                    _ventDirectionNow = (ventDirectionNow % 360) - 180;
                }
                else if (ventDirectionNow>360)
                {
                    _ventDirectionNow = (ventDirectionNow % 360) + 180;
                }
                else
                {
                    _ventDirectionNow = 0;
                }

                meteo.TemperatureNow = temperatureCelciusNow.ToString("0.0") + " °C";
                meteo.PressionNow = pressionNow.ToString() + " hPa";
                meteo.PluieNow = (string)results[creneauMeteoNow]["pluie"] + " mm";
                meteo.VentVitesseNow = (string)results[creneauMeteoNow]["vent_moyen"]["10m"] + " km/h";
                meteo.VentDirectionNow = _ventDirectionNow + " °";
                meteo.NebulositeNow = (string)results[creneauMeteoNow]["nebulosite"]["totale"] +  " %";
                meteo.RisqueNeigeNow = (string)results[creneauMeteoNow]["risque_neige"];

                /* Meteo +6h */
                double temperatureKelvinH6 = double.Parse((string)results[creneauMeteoH6]["temperature"]["sol"],
                    System.Globalization.CultureInfo.InvariantCulture);
                double temperatureCelciusH6 = temperatureKelvinH6 - 273.15;

                meteo.TemperatureH6 = temperatureCelciusH6.ToString("0.0") + " °C";

                /* Meteo +12h */
                double temperatureKelvinH12 = double.Parse((string)results[creneauMeteoH12]["temperature"]["sol"],
                    System.Globalization.CultureInfo.InvariantCulture);
                double temperatureCelciusH12 = temperatureKelvinH12 - 273.15;

                meteo.TemperatureH12 = temperatureCelciusH12.ToString("0.0") + " °C";


                return meteo;
            }
            
            else
            {
                /* Code de retour différent de 200 */
                Meteo meteo = new Meteo();

                return meteo;
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
