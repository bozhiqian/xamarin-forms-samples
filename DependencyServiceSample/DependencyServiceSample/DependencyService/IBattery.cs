namespace DependencyServiceSample.DependencyService
{
    public interface IBattery
	{
		int RemainingChargePercent { get; }
		BatteryStatus Status { get; }
		PowerSource PowerSource { get; }
	}
}

