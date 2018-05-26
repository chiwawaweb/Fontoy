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
                int ventVitesseMoyenne = (int)results["current_condition"]["wnd_spd"];
                int ventVitesseRafales = (int)results["current_condition"]["wnd_gust"];
                int humidite = (int)results["current_condition"]["humidity"];
                double pression = (double)results["current_condition"]["pressure"];
                string ventDirection = (string)results["current_condition"]["wnd_dir"];
                string conditions = (string)results["current_condition"]["condition_key"];

                /* Conversion des données */
                string conditionsImage = "meteo_" + conditions.Replace("-","_") + "_big";
                string ventDirectionImage = "meteo_vent_" + ventDirection.ToLower();

                /* Envoi des données */
                meteo.Temperature = temperature + " °C";
                meteo.VentDirectionImage = ventDirectionImage;
                meteo.VentVitesseMoyenne = ventVitesseMoyenne + " km/h";
                meteo.VentVitesseRafales = ventVitesseRafales + " km/h";
                meteo.Humidite = humidite + " %";
                meteo.Pression = pression + " hPa";
                meteo.ConditionsImage = conditionsImage;

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
