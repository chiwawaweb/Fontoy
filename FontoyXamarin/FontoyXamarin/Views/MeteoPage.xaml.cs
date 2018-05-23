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
            Title = "Météo";

            InitializeComponent ();

            ViewMeteo();
        }

        private async void ViewMeteo()
        {
            Weather weatherNow = await Core.GetWeather(DateTime.Now);
            
            /* Affiche la température */
            TempNow.Text = weatherNow.Temperature;
            creneauNow.Text = weatherNow.Title;

            Weather weatherH6 = await Core.GetWeather(DateTime.Now.AddHours(6));
            TempH6.Text = weatherH6.Temperature;
            creneauH6.Text = weatherH6.Title;

            Weather weatherH12 = await Core.GetWeather(DateTime.Now.AddHours(12));
            TempH12.Text = weatherH12.Temperature;
            creneauH12.Text = weatherH12.Title;
        }
	}
}