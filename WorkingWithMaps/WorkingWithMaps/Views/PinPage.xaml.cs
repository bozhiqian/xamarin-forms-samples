using WorkingWithMaps.ViewModels;
using Xamarin.Forms;
using Xamarin.Forms.Maps;

namespace WorkingWithMaps.Views
{
    public partial class PinPage : ContentPage
    {
        public PinPage()
        {
            InitializeComponent();
            ViewModel.GoogleMap = GoogleMap;

            var position = new Position(36.9628066, -122.0194722); // Latitude, Longitude

            GoogleMap.MoveToRegion(MapSpan.FromCenterAndRadius(position, Distance.FromMiles(3))); // Santa Cruz golf course

            var pin = new Pin
            {
                Type = PinType.Place,
                Position = position,
                Label = "Santa Cruz",
                Address = "custom detail info"
            };
            GoogleMap.Pins.Add(pin);

        }

        public PinPageViewModel ViewModel => BindingContext as PinPageViewModel;


    }
}
