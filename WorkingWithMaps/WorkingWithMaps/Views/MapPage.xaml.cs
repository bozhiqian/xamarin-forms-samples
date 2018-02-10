using WorkingWithMaps.ViewModels;
using Xamarin.Forms;
using Xamarin.Forms.Maps;

namespace WorkingWithMaps.Views
{
    public partial class MapPage : ContentPage
    {
        public MapPage()
        {
            InitializeComponent();

            ViewModel.GoogleMap = GoogleMap;
            GoogleMap.MoveToRegion(new MapSpan(new Position(0, 0), 360, 360));
        }

        public MapPageViewModel ViewModel => BindingContext as MapPageViewModel;
    }
}
