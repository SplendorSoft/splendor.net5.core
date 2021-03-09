using System;
using System.Runtime.InteropServices;

namespace splendor.net5.core.tools.date
{
    public static class TimeZoneExtensions
    {
        private static TimeZoneInfo _americaLimaTimeZone = null;
        public static TimeZoneInfo AmericaLimaTimeZone => _americaLimaTimeZone;
        private static void StartupAmericaLimaTimeZone()
        {
            bool isWindows = RuntimeInformation.IsOSPlatform(OSPlatform.Windows);
            if (_americaLimaTimeZone == null)
            {
                if (isWindows)
                {
                    try
                    {                         
                        _americaLimaTimeZone = TimeZoneInfo.FindSystemTimeZoneById("SA Pacific Standard Time");
                    }
                    catch (TimeZoneNotFoundException)
                    {
                        _americaLimaTimeZone = TimeZoneInfo.FindSystemTimeZoneById("Lima, Peru");
                    }
                    catch (InvalidTimeZoneException)
                    {
                        _americaLimaTimeZone = TimeZoneInfo.FindSystemTimeZoneById("Lima, Peru");
                    }
                }
                else
                {
                    _americaLimaTimeZone = TimeZoneInfo.FindSystemTimeZoneById("America/Lima");
                }
            }
        }
        public static DateTime AmericaLima(this DateTime date)
        {
            StartupAmericaLimaTimeZone();
            return TimeZoneInfo.ConvertTimeFromUtc(date, _americaLimaTimeZone);
        }
    }
}