using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace FontoyXamarin.Views
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class MeteoPage : ContentPage
	{
        DateTime DateHeureCourante;

        public MeteoPage ()
		{
			InitializeComponent ();

            ViewMeteo();

            ViewDateHeureCourante();
        }

        private async void ViewMeteo()
        {
            Weather weather = await Core.GetWeather();
            
            /* Affiche la température */
            Temp.Text = weather.Temperature;
        }

        private void ViewDateHeureCourante()
        {
            /* Définit le créneau actuel le plus proche des heures 03/05/08/11/14/17/20/23 */
            DateHeureCourante = DateTime.Now;

            HeureCourante.Text = CalculCreneau(DateTime.Now.ToShortDateString(), DateTime.Now.ToLongTimeString());
        }

        private string CalculCreneau(string date, string heure)
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