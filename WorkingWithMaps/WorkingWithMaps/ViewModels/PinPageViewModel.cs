using Prism.Commands;
using Prism.Mvvm;
using System;
using System.Collections.Generic;
using System.Linq;
using Xamarin.Forms.Maps;

namespace WorkingWithMaps.ViewModels
{
	public class PinPageViewModel : BindableBase
	{
	    private Map _googleMap;
	    private string _title;

        public PinPageViewModel()
        {
            Title = "Pins";

            AddMorePinsCommand = new DelegateCommand(AddMorePins);
            RelocateCommand = new DelegateCommand(Relocate);
        }

	    public string Title
	    {
	        get => _title;
	        set => SetProperty(ref _title, value);
	    }

        public DelegateCommand AddMorePinsCommand { get; }
        public DelegateCommand RelocateCommand { get; }

        public Map GoogleMap
	    {
	        get => _googleMap;
	        set => SetProperty(ref _googleMap, value);
	    }

	    public void AddMorePins()
	    {
	        GoogleMap.Pins.Add(new Pin
	        {
	            Position = new Position(36.9641949, -122.0177232),
	            Label = "Boardwalk"
	        });

	        GoogleMap.Pins.Add(new Pin
	        {
	            Position = new Position(36.9571571, -122.0173544),
	            Label = "Wharf"
	        });

	        GoogleMap.MoveToRegion(MapSpan.FromCenterAndRadius(new Position(36.9628066, -122.0194722), Distance.FromMiles(1.5)));
        }

	    public void Relocate()
	    {
	        GoogleMap.MoveToRegion(MapSpan.FromCenterAndRadius(new Position(36.9628066, -122.0194722), Distance.FromMiles(3)));
        }
    }
}
