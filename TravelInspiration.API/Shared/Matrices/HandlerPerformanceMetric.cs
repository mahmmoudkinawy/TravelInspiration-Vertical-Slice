using System.Diagnostics.Metrics;

namespace TravelInspiration.API.Shared.Matrices;

public class HandlerPerformanceMetric
{
	private readonly Counter<long> _milliSecondsElapsed;

	public HandlerPerformanceMetric(IMeterFactory meterFactory)
	{
		var meter = meterFactory.Create("TravelInspiration.API");
		_milliSecondsElapsed = meter.CreateCounter<long>("travelinspiration.api.requesthandler.millisecondselapsed");
	}

	public void MillSecondsElapsed(long milliseconds)
	{
		_milliSecondsElapsed.Add(milliseconds);
	}
}
