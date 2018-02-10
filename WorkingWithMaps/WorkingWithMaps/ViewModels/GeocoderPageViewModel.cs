using Prism.Commands;
using Prism.Mvvm;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Xamarin.Forms.Maps;

namespace WorkingWithMaps.ViewModels
{
    public class GeocoderPageViewModel : BindableBase
    {
        readonly Geocoder _geoCoder;
        private string _location;
        private string _title;

        public GeocoderPageViewModel()
        {
            Title = "Geocode";
            _geoCoder = new Geocoder();
            GetAddressesForPositionCommand = new DelegateCommand(async () => await GetAddressesForPositionAsync());
            GetPositionsForAddressCommand = new DelegateCommand(async () => await GetPositionsForAddressAsync());
        }

        public string Title
        {
            get => _title;
            set => SetProperty(ref _title, value);
        }
        public DelegateCommand GetAddressesForPositionCommand { get; }
        public DelegateCommand GetPositionsForAddressCommand { get; }

        public string Location
        {
            get => _location;
            set => SetProperty(ref _location, value);
        }

        public async Task GetAddressesForPositionAsync()
        {
            var fortMasonPosition = new Position(37.7977705, -122.4040947);
            var possibleAddresses = await _geoCoder.GetAddressesForPositionAsync(fortMasonPosition);
            string location = string.Empty;
            foreach (var a in possibleAddresses)
            {
                location += a + "\n";
            }

            Location = location;
        }

        public async Task GetPositionsForAddressAsync()
        {
            var xamarinAddress = "394 Pacific Ave, San Francisco, California, USA";
            var approximateLocation = await _geoCoder.GetPositionsForAddressAsync(xamarinAddress);

            string location = string.Empty;
            foreach (var p in approximateLocation)
            {
                location += p.Latitude + ", " + p.Longitude + "\n";
            }

            Location = location;
        }
    }
}
