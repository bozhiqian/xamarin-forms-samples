using System;
using System.Diagnostics;
using Prism.Commands;
using Prism.Mvvm;
using Xamarin.Forms.Maps;

namespace WorkingWithMaps.ViewModels
{
    public class MapPageViewModel : BindableBase
    {
        private MapSpan _mapVisibleRegion;

        //private DelegateCommand<double> _moveSliderCommand;

        //public DelegateCommand<double> MoveSliderCommand => _moveSliderCommand ?? (_moveSliderCommand = new DelegateCommand<double>(MoveSlider));
        public DelegateCommand StreetCommand { get; }
        public DelegateCommand HybridCommand { get; }
        public DelegateCommand SatelliteCommand { get; }
        private MapType _mapType;
        private Map _googleMap;
        private string _title;
        private double _sliderValue = 1;

        public MapPageViewModel()
        {
            Title = "Map/Zoom";

            //MoveSliderCommand = new DelegateCommand<double>(MoveSlider);
            StreetCommand = new DelegateCommand(() =>
            {
                MapType = MapType.Street;
            });

            HybridCommand = new DelegateCommand(() => { MapType = MapType.Hybrid; });
            SatelliteCommand = new DelegateCommand(() => { MapType = MapType.Satellite; });
        }

        public string Title
        {
            get => _title;
            set => SetProperty(ref _title, value);
        }

        public double SliderValue
        {
            get => _sliderValue;
            set
            {
                SetProperty(ref _sliderValue, value);
                MoveSlider(_sliderValue);
            }
        }

        public Map GoogleMap
        {
            get => _googleMap;
            set => SetProperty(ref _googleMap, value);
        }

        public MapSpan MapVisibleRegion
        {
            get => _mapVisibleRegion;
            set
            {
                SetProperty(ref _mapVisibleRegion, value);
                CalculateBoundingCoordinates(_mapVisibleRegion);
            }
        }

        public MapType MapType
        {
            get => _mapType;
            set => SetProperty(ref _mapType, value);
        }

        public void MoveSlider(double newValue)
        {
            var zoomLevel = newValue; // between 1 and 18
            var latlongdegrees = 360 / (Math.Pow(2, zoomLevel));
            Debug.WriteLine(zoomLevel + " -> " + latlongdegrees);
            if (GoogleMap.VisibleRegion != null)
            {
                GoogleMap.MoveToRegion(new MapSpan(GoogleMap.VisibleRegion.Center, latlongdegrees, latlongdegrees));
            }
        }

        /// <summary>
        /// In response to this forum question http://forums.xamarin.com/discussion/22493/maps-visibleregion-bounds
        /// Useful if you need to send the bounds to a web service or otherwise calculate what
        /// pins might need to be drawn inside the currently visible viewport.
        /// </summary>
        static void CalculateBoundingCoordinates(MapSpan region)
        {
            // WARNING: I haven't tested the correctness of this exhaustively!
            var center = region.Center;
            var halfheightDegrees = region.LatitudeDegrees / 2;
            var halfwidthDegrees = region.LongitudeDegrees / 2;

            var left = center.Longitude - halfwidthDegrees;
            var right = center.Longitude + halfwidthDegrees;
            var top = center.Latitude + halfheightDegrees;
            var bottom = center.Latitude - halfheightDegrees;

            // Adjust for Internation Date Line (+/- 180 degrees longitude)
            if (left < -180) left = 180 + (180 + left);
            if (right > 180) right = (right - 180) - 180;
            // I don't wrap around north or south; I don't think the map control allows this anyway

            Debug.WriteLine("Bounding box:");
            Debug.WriteLine("                    " + top);
            Debug.WriteLine("  " + left + "                " + right);
            Debug.WriteLine("                    " + bottom);
        }
    }
}