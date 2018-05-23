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

            TempNow.Text = meteo.TemperatureNow;

            TempH6.Text = meteo.TemperatureH6;

            TempH12.Text = meteo.TemperatureH12;
        }
	}
}