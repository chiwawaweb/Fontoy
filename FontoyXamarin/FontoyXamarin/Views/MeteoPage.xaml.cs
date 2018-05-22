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

            //HeureCourante.Text = CalculCreneau(DateTime.Now.ToShortDateString(), DateTime.Now.ToLongTimeString());
        }

        
	}
}