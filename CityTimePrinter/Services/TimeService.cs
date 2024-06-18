using NodaTime;
using NodaTime.TimeZones;

namespace CityTimePrinter.Services
{
	public interface ITimeService
	{
		ZonedDateTime GetCurrentTime(string timeZoneId);
	}

	public class TimeService : ITimeService
	{
		private readonly IDateTimeZoneProvider _timeZoneProvider;

		public TimeService()
		{
			_timeZoneProvider = DateTimeZoneProviders.Tzdb;
		}

		public ZonedDateTime GetCurrentTime(string timeZoneId)
		{
			var timeZone = _timeZoneProvider[timeZoneId];
			var now = SystemClock.Instance.GetCurrentInstant();
			return now.InZone(timeZone);
		}
	}
}
