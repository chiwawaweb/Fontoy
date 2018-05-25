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

            

            /*
            PressionNow.Text = meteo.PressionNow;
            VentMoyenVitesseNow.Text = meteo.VentMoyenVitesseNow;
            VentRafalesVitesseNow.Text = meteo.VentRafalesVitesseNow;
            HumiditeNow.Text = meteo.HumiditeNow;

            VentDirection.Source = "iconFleche";
            VentDirection.Rotation = int.Parse(meteo.VentDirectionNow);
            */
        }
	}
}