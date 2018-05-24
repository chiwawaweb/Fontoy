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
            Meteo meteo = await CoreMeteo.GetMeteo(DateTime.Now);

            TemperatureNow.Text = meteo.TemperatureNow;
            PressionNow.Text = meteo.PressionNow;
            PluieNow.Text = meteo.PluieNow;
            VentVitesseNow.Text = meteo.VentVitesseNow;
            VentDirectionNow.Text = meteo.VentDirectionNow;
            NebulositeNow.Text = meteo.NebulositeNow;
            RisqueNeigeNow.Text = meteo.RisqueNeigeNow.ToUpper();

            TemperatureH6.Text = meteo.TemperatureH6;

            TemperatureH12.Text = meteo.TemperatureH12;

            VentDirection.Source = "iconFleche";
            VentDirection.Rotation = int.Parse(meteo.VentDirectionNow);
        }
	}
}