using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace FontoyXamarin
{
    public class CoreMeteo
    {
        public static async Task<Meteo> GetMeteo()
        {
            string queryString = "https://www.prevision-meteo.ch/services/json/fontoy";

            dynamic results = await DataService.getDataFromService(queryString).ConfigureAwait(false);


            if ((string)results["city_info"]["name"]=="Fontoy")
            {
                Meteo meteo = new Meteo();

                /* Récupération des données JSON */
                int temperature = (int)results["current_condition"]["tmp"];

                Console.WriteLine((string)results["current_condition"]["condition_key"]);
                /*
                int jsonPressionNow = (int)results[creneauMeteoNow]["pression"]["niveau_de_la_mer"];
                int jsonVentDirectionNow = (int)results[creneauMeteoNow]["vent_direction"]["10m"];
                double jsonVentMoyenVitesse = (double)results[creneauMeteoNow]["vent_moyen"]["10m"];
                double jsonVentRafalesVitesse = (double)results[creneauMeteoNow]["vent_rafales"]["10m"];
                int jsonHumiditeNow = (int)results[creneauMeteoNow]["humidite"]["2m"];
                */

                /* Conversion des données */


                /* Envoi des données */
                meteo.Temperature = temperature + " °C";


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
