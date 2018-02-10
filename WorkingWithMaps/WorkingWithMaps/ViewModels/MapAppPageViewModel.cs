using Prism.Commands;
using Prism.Mvvm;
using System;
using System.Collections.Generic;
using System.Linq;
using Xamarin.Forms;

namespace WorkingWithMaps.ViewModels
{
    public class MapAppPageViewModel : BindableBase
    {
        private string _title;

        public MapAppPageViewModel()
        {
            Title = "Map App";
            OpenLocationCommand = new DelegateCommand(OpenLocation);
            OpenDirectionsCommand = new DelegateCommand(OpenDirections);
        }

        public string Title
        {
            get => _title;
            set => SetProperty(ref _title, value);
        }
        public DelegateCommand OpenLocationCommand { get; }

        public DelegateCommand OpenDirectionsCommand { get; }

        private void OpenLocation()
        {
            try
            {
                if (Device.RuntimePlatform == Device.iOS)
                {
                    //https://developer.apple.com/library/ios/featuredarticles/iPhoneURLScheme_Reference/MapLinks/MapLinks.html
                    Device.OpenUri(new Uri("http://maps.apple.com/?q=394+Pacific+Ave+San+Francisco+CA"));
                }
                else if (Device.RuntimePlatform == Device.Android)
                {
                    // opens the Maps app directly
                    // Device.OpenUri(new Uri("geo:0,0?q=394+Pacific+Ave+San+Francisco+CA"));
                    Device.OpenUri(new Uri("http://maps.apple.com/?q=394+Pacific+Ave+San+Francisco+CA"));

                }
                else if (Device.RuntimePlatform == Device.UWP || Device.RuntimePlatform == Device.WinPhone)
                {
                    Device.OpenUri(new Uri("bingmaps:?where=394 Pacific Ave San Francisco CA"));
                }

            }
            catch (Exception e)
            {

            }
        }

        private void OpenDirections()
        {
            try
            {
                if (Device.RuntimePlatform == Device.iOS)
                {
                    //https://developer.apple.com/library/ios/featuredarticles/iPhoneURLScheme_Reference/MapLinks/MapLinks.html
                    Device.OpenUri(new Uri("http://maps.apple.com/?daddr=San+Francisco,+CA&saddr=cupertino"));

                }
                else if (Device.RuntimePlatform == Device.Android)
                {
                    // opens the 'task chooser' so the user can pick Maps, Chrome or other mapping app
                    Device.OpenUri(new Uri("http://maps.google.com/?daddr=San+Francisco,+CA&saddr=Mountain+View,+CA"));

                }
                else if (Device.RuntimePlatform == Device.UWP)
                {
                    Device.OpenUri(new Uri("bingmaps:?rtp=adr.394 Pacific Ave San Francisco CA~adr.One Microsoft Way Redmond WA 98052"));
                }

            }
            catch (Exception e)
            {

            }
        }
    }
}
