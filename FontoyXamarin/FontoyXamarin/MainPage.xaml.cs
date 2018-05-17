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
			

            Title = "Todo";

            var toolbarItem = new ToolbarItem
            {
                Text = "+",
                Icon = Device.RuntimePlatform == Device.iOS ? null : "plus.png"
            };
            toolbarItem.Clicked += async (sender, e) =>
            {
                
            };
            ToolbarItems.Add(toolbarItem);

            InitializeComponent();
        }

        private void OnItemAdded(EventArgs e)
        {
            Console.WriteLine("clicked");
        }
	}
}
