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
        public MeteoPage ()
		{
            Title = "Météo à Fontoy";

            InitializeComponent ();

            ViewMeteo();
        }

        private async void ViewMeteo()
        {
            
            Meteo meteo = await CoreMeteo.GetMeteo();
            
            Temperature.Text = meteo.Temperature;
            VentDirectionImage.Source = meteo.VentDirectionImage;
            VentVitesseMoyenne.Text = meteo.VentVitesseMoyenne;
            VentVitesseRafales.Text = meteo.VentVitesseRafales;
            ConditionsImage.Source = meteo.ConditionsImage;

            //Console.WriteLine(meteo.ConditionsImage); // tmp test

        }
	}
}