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

            /*
            Humidite.Text = meteo.Humidite;
            Pression.Text = meteo.Pression;
            */
            Conditions.Text = meteo.Conditions;
            ConditionsImage.Source = meteo.ConditionsImage;
            HoraireLeverSoleil.Text = meteo.LeverSoleil;
            HoraireCoucherSoleil.Text = meteo.CoucherSoleil;
            
        }
	}
}