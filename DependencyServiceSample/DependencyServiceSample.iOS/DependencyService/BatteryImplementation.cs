using DependencyServiceSample.DependencyService;
using DependencyServiceSample.iOS.DependencyService;
using UIKit;
using Xamarin.Forms;

[assembly: Dependency(typeof(BatteryImplementation))]

namespace DependencyServiceSample.iOS.DependencyService
{
    public class BatteryImplementation : IBattery
    {
        public BatteryImplementation()
        {
            UIDevice.CurrentDevice.BatteryMonitoringEnabled = true;
        }

        public int RemainingChargePercent => (int) (UIDevice.CurrentDevice.BatteryLevel * 100F);

        public BatteryStatus Status
        {
            get
            {
                switch (UIDevice.CurrentDevice.BatteryState)
                {
                    case UIDeviceBatteryState.Charging:
                        return BatteryStatus.Charging;
                    case UIDeviceBatteryState.Full:
                        return BatteryStatus.Full;
                    case UIDeviceBatteryState.Unplugged:
                        return BatteryStatus.Discharging;
                    default:
                        return BatteryStatus.Unknown;
                }
            }
        }

        public PowerSource PowerSource
        {
            get
            {
                switch (UIDevice.CurrentDevice.BatteryState)
                {
                    case UIDeviceBatteryState.Charging:
                        return PowerSource.Ac;
                    case UIDeviceBatteryState.Full:
                        return PowerSource.Ac;
                    case UIDeviceBatteryState.Unplugged:
                        return PowerSource.Battery;
                    default:
                        return PowerSource.Other;
                }
            }
        }
    }
}