using DependencyServiceSample.DependencyService;
using DependencyServiceSample.iOS.DependencyService;
using UIKit;
using Xamarin.Forms;

[assembly: Dependency(typeof(DeviceOrientationImplementation))]

namespace DependencyServiceSample.iOS.DependencyService
{
    public class DeviceOrientationImplementation : IDeviceOrientation
    {
        public DeviceOrientations GetOrientation()
        {
            var currentOrientation = UIApplication.SharedApplication.StatusBarOrientation;
            var isPortrait = currentOrientation == UIInterfaceOrientation.Portrait
                             || currentOrientation == UIInterfaceOrientation.PortraitUpsideDown;

            return isPortrait ? DeviceOrientations.Portrait : DeviceOrientations.Landscape;
        }
    }
}