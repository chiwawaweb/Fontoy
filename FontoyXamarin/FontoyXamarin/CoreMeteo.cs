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

                /* Case B : conditions actuelles */
                /* Récupération des données JSON */
                int temperature = (int)results["current_condition"]["tmp"];
                int ventVitesseMoyenne = (int)results["current_condition"]["wnd_spd"];
                int ventVitesseRafales = (int)results["current_condition"]["wnd_gust"];
                int humidite = (int)results["current_condition"]["humidity"];
                double pression = (double)results["current_condition"]["pressure"];
                string ventDirection = (string)results["current_condition"]["wnd_dir"];
                string conditionsKey = (string)results["current_condition"]["condition_key"];
                string conditions = (string)results["current_condition"]["condition"];
                string leverSoleil = (string)results["city_info"]["sunrise"];
                string coucherSoleil = (string)results["city_info"]["sunset"];

                /* Conversion des données */
                string conditionsImage = "meteo_" + conditionsKey.Replace("-","_") + "_big";
                string ventDirectionImage = "meteo_vent_" + ventDirection.ToLower();
                string horaireLeverSoleil = leverSoleil.Replace(":", "h");
                string horaireCoucherSoleil = coucherSoleil.Replace(":", "h");

                /* Envoi des données */
                meteo.Temperature = temperature + " °C";
                meteo.VentDirectionImage = ventDirectionImage;
                meteo.VentVitesseMoyenne = "Vent moyen : " + ventVitesseMoyenne + " km/h";
                meteo.VentVitesseRafales = "Rafales : " + ventVitesseRafales + " km/h";
                meteo.Humidite = "Humidité : " + humidite + " %";
                meteo.Pression = "Pression : " + pression + " hPa";
                meteo.Conditions = conditions;
                meteo.ConditionsImage = conditionsImage;
                meteo.LeverSoleil = horaireLeverSoleil;
                meteo.CoucherSoleil = horaireCoucherSoleil;

                /* Case B : Détermine le type d'info */

                /*
                 * A : Entre 6h et 18h 
                 * B : soir 20h
                 * C : nuit 3h
                 * 
                 * A : Entre 18h et 24h
                 * B : nuit 3h
                 * C : lendemain journée
                 * 
                 * A : Entre 0h et 6h
                 * B : matin 8h
                 * C : après-midi 14h
                 */
                return meteo;
                
            }
            
            else
            {
                /* Problème dans le retour JSON */
                Meteo meteo = new Meteo();

                return meteo;
            }
        }
    }
}
