using FontoyXamarin.Views;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace FontoyXamarin
{
	public partial class MainPage : ContentPage
	{
        public MainPage()
        {
            Title = "Accueil";


            /*var toolbarItem = new ToolbarItem
            {
                Text = "...",
                Icon = Device.RuntimePlatform == Device.iOS ? null : "plus.png"
            };
            toolbarItem.Clicked += async (sender, e) =>
            {

            };
            ToolbarItems.Add(toolbarItem);
            */

            /*
            myLabel = new Label
            {
                Margin = new Thickness(20),
                //FontSize = 25,
                //FontAttributes = FontAttributes.Bold,
                Text = "Je suis un label rouge"
            };

            Content = myLabel;
            */
          

            InitializeComponent();
        }

        async void OnMenuClic(EventArgs e)
        {
            Console.WriteLine("Menu cliqué ! \n");
        }

        async void OnActualiteClic(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new ActualitePage
            {
                BindingContext = new ActualitePage()
            });
        }

        async void OnFacebookClic(object sender, EventArgs e)
        {

        }

        async void OnAgendaClic(object sender, EventArgs e)
        {

        }

        async void OnMeteoClic(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new MeteoPage
            {
                BindingContext = new MeteoPage()
            });
        }
    }
}
