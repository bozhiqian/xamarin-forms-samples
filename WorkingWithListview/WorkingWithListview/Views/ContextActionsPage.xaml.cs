using WorkingWithListview.ViewModels;
using Xamarin.Forms;

namespace WorkingWithListview.Views
{
    public partial class ContextActionsPage : ContentPage
    {
        public ContextActionsPage()
        {
            InitializeComponent();

            // Subscribe to a message (which the ViewModel has also subscribed to) to pop up an Alert
            MessagingCenter.Subscribe<CustomCellPageViewModel, string>(this, "Tapped", (vm, arg) => {
                DisplayAlert("Tapped", arg, "OK");
            });

            MessagingCenter.Subscribe<CustomCellPageViewModel, string>(this, "Clicked", (vm, arg) => {
                DisplayAlert("Clicked", arg, "OK");
            });
        }
    }
}
