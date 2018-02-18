using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UsingMessagingCenter.ViewModels;
using Xamarin.Forms;

namespace UsingMessagingCenter.Views
{
	public partial class MainPage : ContentPage
	{
		public MainPage ()
		{
			InitializeComponent ();

		    // Subscribe to a message (which the ViewModel has also subscribed to) to pop up an Alert
		    MessagingCenter.Subscribe<MainPageViewModel, string>(this, "Hi", (sender, arg) =>
		    {
                DisplayAlert("Hi", arg, "OK");
		    });

            // Subscribe to a message (which the ViewModel has also subscribed to) to pop up an Alert
            MessagingCenter.Subscribe<MainPageViewModel, string>(this, "Unsubscribed", (sender, arg) => {
		        DisplayAlert("Unsubscribed", arg, "OK");
		        MessagingCenter.Unsubscribe<MainPageViewModel, string>(this, "Hi");
		        ViewModel.Subscribed = false;
		    });
        }

        private MainPageViewModel ViewModel => this.BindingContext as MainPageViewModel;
	}
}