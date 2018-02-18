using Xamarin.Forms;

namespace WorkingWithListview.Views
{
    public partial class CustomCellPage : ContentPage
    {
        public CustomCellPage()
        {
            InitializeComponent();

            // Subscribe to a message (which the ViewModel has also subscribed to) to pop up an Alert
            MessagingCenter.Subscribe<MainPage, string>(this, "Hi", (sender, arg) => {
                DisplayAlert(sender.ToString(), arg, "OK");
            });
        }
    }
}
