using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using InteractivityListView.ViewModels;
using Xamarin.Forms;

namespace InteractivityListView.Views
{
	public partial class MainPage : ContentPage
	{
		public MainPage ()
		{
			InitializeComponent ();

		    // Subscribe to a message (which the ViewModel has also subscribed to) to pop up an Alert
		    MessagingCenter.Subscribe<MainPageViewModel, string>(this, "Tapped", (vm, arg) => {
		        DisplayAlert("Tapped", arg, "OK");
		    });

		    MessagingCenter.Subscribe<MainPageViewModel, string>(this, "More Context Action", (vm, arg) => {
		        DisplayAlert("More Context Action", arg, "OK");
		    });
        }
	}
}