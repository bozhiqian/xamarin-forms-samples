using Windows.UI.ViewManagement;
using DependencyServiceSample.DependencyService;
using DependencyServiceSample.UWP.DependencyService;
using Xamarin.Forms;

[assembly: Dependency(typeof(DeviceOrientationImplementation))]

namespace DependencyServiceSample.UWP.DependencyService
{
    public class DeviceOrientationImplementation : IDeviceOrientation
    {
        public DeviceOrientations GetOrientation()
        {
            var orientation = ApplicationView.GetForCurrentView().Orientation;
            if (orientation == ApplicationViewOrientation.Landscape)
                return DeviceOrientations.Landscape;
            return DeviceOrientations.Portrait;
        }
    }
}