using Windows.Devices.Power;
using DependencyServiceSample.DependencyService;
using DependencyServiceSample.UWP.DependencyService;
using Xamarin.Forms;

[assembly: Dependency(typeof(BatteryImplementation))]

namespace DependencyServiceSample.UWP.DependencyService
{
    public class BatteryImplementation : IBattery
    {
        private Battery _battery;
        private BatteryStatus _status = BatteryStatus.Unknown;

        private Battery DefaultBattery => _battery ?? (_battery = Battery.AggregateBattery);

        public int RemainingChargePercent
        {
            get
            {
                var finalReport = DefaultBattery.GetReport();
                var finalPercent = -1;

                if (finalReport.RemainingCapacityInMilliwattHours.HasValue &&
                    finalReport.FullChargeCapacityInMilliwattHours.HasValue)
                    finalPercent = (int) (finalReport.RemainingCapacityInMilliwattHours.Value /
                                          (double) finalReport.FullChargeCapacityInMilliwattHours.Value * 100);
                return finalPercent;
            }
        }

        public BatteryStatus Status
        {
            get
            {
                var report = DefaultBattery.GetReport();
                var percentage = RemainingChargePercent;

                if (percentage >= 1.0)
                    _status = BatteryStatus.Full;
                else if (percentage < 0)
                    _status = BatteryStatus.Unknown;
                else
                    switch (report.Status)
                    {
                        case Windows.System.Power.BatteryStatus.Charging:
                            _status = BatteryStatus.Charging;
                            break;
                        case Windows.System.Power.BatteryStatus.Discharging:
                            _status = BatteryStatus.Discharging;
                            break;
                        case Windows.System.Power.BatteryStatus.Idle:
                            _status = BatteryStatus.NotCharging;
                            break;
                        case Windows.System.Power.BatteryStatus.NotPresent:
                            _status = BatteryStatus.Unknown;
                            break;
                    }
                return _status;
            }
        }

        public PowerSource PowerSource
        {
            get
            {
                if (_status == BatteryStatus.Full || _status == BatteryStatus.Charging) return PowerSource.Ac;
                return PowerSource.Battery;
            }
        }
    }
}