using WorkingWithListview.ViewModels;
using Xamarin.Forms;

namespace WorkingWithListview.Views
{
    public partial class UnevenRowsPage : ContentPage
    {
        public UnevenRowsPage()
        {
            InitializeComponent();

            // Subscribe to a message (which the ViewModel has also subscribed to) to pop up an Alert
            MessagingCenter.Subscribe<UnevenRowsPageViewModel, string>(this, "Tapped", (vm, arg) => {
                DisplayAlert("Tapped", arg, "OK");
            });
        }
    }
}
