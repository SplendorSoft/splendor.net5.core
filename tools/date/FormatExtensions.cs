using System;
using System.Globalization;

namespace splendor.net5.core.tools.date
{
    public static class DateFormats
    {
        public const string LATIN_DATE = "dd/MM/yyyy";
        public const string LATIN_DATE_HOUR_24 = "dd/MM/yyyy HH:mm";
        public const string LATIN_DATE_TIME_FULL_COMPACT = "ddMMyyyyHHmmss";
        public const string LATIN_DATE_HOUR = "dd/MM/yyyy hh:mm";
        public const string LATIN_DATE_TIME_FULL = "dd/MM/yyyy HH:mm:ss";
        public const string LATIN_DATE_TIME_MILIS = "dd/MM/yyyy HH:mm:ss.fff";
        public const string LATIN_TIME_24 = "HH:mm";
        public const string LATIN_TIME_FULL_24 = "HH:mm:ss";
        public const string LATIN_TIME_12 = "hh:mm tt";
        public const string USA_DATE = "yyyy-MM-dd";
        public const string USA_DATE_TIME = "yyyy-MM-dd HH:mm:ss";        
    }
    public static class FormatExtensions
    {
        /// <summary>
        /// Return string in format: <see cref="DateFormats.LATIN_DATE"/>
        /// </summary>
        /// <returns>string ref date</returns>
        public static string LatinDate(this DateTime date)
        {
            return date.ToString(DateFormats.LATIN_DATE, CultureInfo.InvariantCulture);
        }
        /// <summary>
        /// Return date in format: <see cref="DateFormats.LATIN_DATE"/>
        /// </summary>
        /// <returns>date ref string</returns>
        public static DateTime LatinDate(this string date)
        {
            return DateTime.ParseExact(date,
                    DateFormats.LATIN_DATE, CultureInfo.InvariantCulture);
        }
        /// <summary>
        /// Return true try string value parse in format: <see cref="DateFormats.LATIN_DATE"/>
        /// </summary>
        /// <returns>true or false</returns>
        public static bool TryLatinDate(this string date, out DateTime outDate)
        {
            return DateTime.TryParseExact(date, DateFormats.LATIN_DATE,
                CultureInfo.InvariantCulture, DateTimeStyles.None, out outDate);
        }
        
        /// <summary>
        /// Return string in format: <see cref="DateFormats.LATIN_DATE_HOUR_24"/>
        /// </summary>
        /// <returns>string ref date</returns>
        public static string LatinDateTime24(DateTime date)
        {
            return date.ToString(DateFormats.LATIN_DATE_HOUR_24, CultureInfo.InvariantCulture);
        }
        /// <summary>
        /// Return date in format: <see cref="DateFormats.LATIN_DATE_HOUR_24"/>
        /// </summary>
        /// <returns>date ref string</returns>
        public static DateTime LatinDateTime24(this string date)
        {
            return DateTime.ParseExact(date,
                    DateFormats.LATIN_DATE_HOUR_24, CultureInfo.InvariantCulture);
        }
        /// <summary>
        /// Return true try string value parse in format: <see cref="DateFormats.LATIN_DATE_HOUR_24"/>
        /// </summary>
        /// <returns>true or false</returns>
        public static bool TryLatinDateTime24(this string date, out DateTime outDate)
        {
            return DateTime.TryParseExact(date, DateFormats.LATIN_DATE_HOUR_24,
                CultureInfo.InvariantCulture, DateTimeStyles.None, out outDate);
        }

        /// <summary>
        /// Return string in format: <see cref="DateFormats.LATIN_DATE_TIME_FULL_COMPACT"/>
        /// </summary>
        /// <param name="date">Date source</param>
        /// <returns>string ref date</returns>
        public static string LatinDateTimeFullCompact(this DateTime date)
        {
            return date.ToString(DateFormats.LATIN_DATE_TIME_FULL_COMPACT, CultureInfo.InvariantCulture);
        }
        /// <summary>
        /// Return date in format: <see cref="DateFormats.LATIN_DATE_TIME_FULL_COMPACT"/>
        /// </summary>
        /// <returns>date ref string</returns>
        public static DateTime LatinDateTimeFullCompact(this string date)
        {
            return DateTime.ParseExact(date,
                    DateFormats.LATIN_DATE_TIME_FULL_COMPACT, CultureInfo.InvariantCulture);
        }
        /// <summary>
        /// Return true try string value parse in format: <see cref="DateFormats.LATIN_DATE_TIME_FULL_COMPACT"/>
        /// </summary>
        /// <returns>true or false</returns>
        public static bool TryLatinDateTimeFullCompact(this string date, out DateTime outDate)
        {
            return DateTime.TryParseExact(date, DateFormats.LATIN_DATE_TIME_FULL_COMPACT,
                CultureInfo.InvariantCulture, DateTimeStyles.None, out outDate);
        }

        /// <summary>
        /// Return string in format: <see cref="DateFormats.LATIN_DATE_HOUR"/>
        /// </summary>
        /// <returns>string ref date</returns>
        public static string LatinDateTime(DateTime date)
        {
            return date.ToString(DateFormats.LATIN_DATE_HOUR, CultureInfo.InvariantCulture);
        }
        /// <summary>
        /// Return date in format: <see cref="DateFormats.LATIN_DATE_HOUR"/>
        /// </summary>
        /// <returns>date ref string</returns>
        public static DateTime LatinDateTime(this string date)
        {
            return DateTime.ParseExact(date,
                    DateFormats.LATIN_DATE_HOUR, CultureInfo.InvariantCulture);
        }
        /// <summary>
        /// Return true try string value parse in format: <see cref="DateFormats.LATIN_DATE_HOUR"/>
        /// </summary>
        /// <returns>true or false</returns>
        public static bool TryLatinDateTime(this string date, out DateTime outDate)
        {
            return DateTime.TryParseExact(date, DateFormats.LATIN_DATE_HOUR,
                CultureInfo.InvariantCulture, DateTimeStyles.None, out outDate);
        }

        /// <summary>
        /// Return string in format: <see cref="DateFormats.LATIN_DATE_TIME_FULL"/>
        /// </summary>
        /// <returns>string ref date</returns>
        public static string LatinDateTimeFull(DateTime date)
        {
            return date.ToString(DateFormats.LATIN_DATE_TIME_FULL, CultureInfo.InvariantCulture);
        }
        /// <summary>
        /// Return date in format: <see cref="DateFormats.LATIN_DATE_TIME_FULL"/>
        /// </summary>
        /// <returns>date ref string</returns>
        public static DateTime LatinDateTimeFull(this string date)
        {
            return DateTime.ParseExact(date,
                    DateFormats.LATIN_DATE_TIME_FULL, CultureInfo.InvariantCulture);
        }
        /// <summary>
        /// Return true try string value parse in format: <see cref="DateFormats.LATIN_DATE_TIME_FULL"/>
        /// </summary>
        /// <returns>true or false</returns>
        public static bool TryLatinDateTimeFull(this string date, out DateTime outDate)
        {
            return DateTime.TryParseExact(date, DateFormats.LATIN_DATE_TIME_FULL,
                CultureInfo.InvariantCulture, DateTimeStyles.None, out outDate);
        }

        /// <summary>
        /// Return string in format: <see cref="DateFormats.LATIN_DATE_TIME_MILIS"/>
        /// </summary>
        /// <returns>string ref date</returns>
        public static string LatinDateTimeMilis(DateTime date)
        {
            return date.ToString(DateFormats.LATIN_DATE_TIME_MILIS, CultureInfo.InvariantCulture);
        }
        /// <summary>
        /// Return date in format: <see cref="DateFormats.LATIN_DATE_TIME_MILIS"/>
        /// </summary>
        /// <returns>date ref string</returns>
        public static DateTime LatinDateTimeMilis(this string date)
        {
            return DateTime.ParseExact(date,
                    DateFormats.LATIN_DATE_TIME_MILIS, CultureInfo.InvariantCulture);
        }
        /// <summary>
        /// Return true try string value parse in format: <see cref="DateFormats.LATIN_DATE_TIME_MILIS"/>
        /// </summary>
        /// <returns>true or false</returns>
        public static bool TryLatinDateTimeMilis(this string date, out DateTime outDate)
        {
            return DateTime.TryParseExact(date, DateFormats.LATIN_DATE_TIME_MILIS,
                CultureInfo.InvariantCulture, DateTimeStyles.None, out outDate);
        }

        /// <summary>
        /// Return string in format: <see cref="DateFormats.LATIN_TIME_24"/>
        /// </summary>
        /// <returns>string ref date</returns>
        public static string LatinTime24(TimeSpan time)
        {
            return time.ToString(@"hh\:mm", CultureInfo.InvariantCulture);
        }
        /// <summary>
        /// Return date in format: <see cref="DateFormats.LATIN_TIME_24"/>
        /// </summary>
        /// <returns>date ref string</returns>
        public static TimeSpan LatinTime24(this string time)
        {
            return DateTime.ParseExact(time, DateFormats.LATIN_TIME_24, CultureInfo.InvariantCulture).TimeOfDay;
        }
        /// <summary>
        /// Return true try string value parse in format: <see cref="DateFormats.LATIN_TIME_24"/>
        /// </summary>
        /// <returns>true or false</returns>
        public static bool TryLatinTime24(this string time, out TimeSpan outTime)
        {
            try
            {
                outTime = DateTime.ParseExact(time, DateFormats.LATIN_TIME_24, CultureInfo.InvariantCulture).TimeOfDay;
                return true;
            }
            catch{
                outTime = default;
                return false;
            }
        }

        /// <summary>
        /// Return string in format: <see cref="DateFormats.LATIN_TIME_FULL_24"/>
        /// </summary>
        /// <returns>string ref date</returns>
        public static string LatinTime24Full(TimeSpan time)
        {
            return time.ToString(@"hh\:mm\:ss", CultureInfo.InvariantCulture);
        }
        /// <summary>
        /// Return date in format: <see cref="DateFormats.LATIN_TIME_FULL_24"/>
        /// </summary>
        /// <returns>date ref string</returns>
        public static TimeSpan LatinTime24Full(this string time)
        {
            return DateTime.ParseExact(time, DateFormats.LATIN_TIME_FULL_24, CultureInfo.InvariantCulture).TimeOfDay;
        }
        /// <summary>
        /// Return true try string value parse in format: <see cref="DateFormats.LATIN_TIME_FULL_24"/>
        /// </summary>
        /// <returns>true or false</returns>
        public static bool TryLatinTime24Full(this string time, out TimeSpan outTime)
        {
            try
            {
                outTime = DateTime.ParseExact(time, DateFormats.LATIN_TIME_FULL_24, CultureInfo.InvariantCulture).TimeOfDay;
                return true;
            }
            catch{
                outTime = default;
                return false;
            }
        }

        /// <summary>
        /// Return string in format: <see cref="DateFormats.LATIN_TIME_12"/>
        /// </summary>
        /// <returns>string ref date</returns>
        public static string LatinTime12(TimeSpan hour)
        {
            return DateTime.Today.Add(hour).ToString(DateFormats.LATIN_TIME_12);
        }
        /// <summary>
        /// Return date in format: <see cref="DateFormats.LATIN_TIME_12"/>
        /// </summary>
        /// <returns>date ref string</returns>
        public static TimeSpan LatinTime12(string hour)
        {
            return DateTime.ParseExact(hour, DateFormats.LATIN_TIME_12, CultureInfo.InvariantCulture).TimeOfDay;
        }
        /// <summary>
        /// Return true try string value parse in format: <see cref="DateFormats.LATIN_TIME_12"/>
        /// </summary>
        /// <returns>true or false</returns>
        public static bool TryLatinTime12(this string time, out TimeSpan outTime)
        {
            try
            {
                outTime = DateTime.ParseExact(time, DateFormats.LATIN_TIME_12, CultureInfo.InvariantCulture).TimeOfDay;
                return true;
            }
            catch{
                outTime = default;
                return false;
            }
        }

        /// <summary>
        /// Return string in format: <see cref="DateFormats.USA_DATE"/>
        /// </summary>
        /// <returns>string ref date</returns>
        public static string UsaDate(this DateTime date)
        {
            return date.ToString(DateFormats.USA_DATE, CultureInfo.InvariantCulture);
        }
        /// <summary>
        /// Return date in format: <see cref="DateFormats.USA_DATE"/>
        /// </summary>
        /// <returns>date ref string</returns>
        public static DateTime UsaDate(this string date)
        {
            return DateTime.ParseExact(date,
                    DateFormats.USA_DATE, CultureInfo.InvariantCulture);
        }
        /// <summary>
        /// Return true try string value parse in format: <see cref="DateFormats.USA_DATE"/>
        /// </summary>
        /// <returns>true or false</returns>
        public static bool TryUsaDate(this string date, out DateTime outDate)
        {
            return DateTime.TryParseExact(date, DateFormats.USA_DATE,
                CultureInfo.InvariantCulture, DateTimeStyles.None, out outDate);
        }

        /// <summary>
        /// Return string in format: <see cref="DateFormats.USA_DATE_TIME"/>
        /// </summary>
        /// <returns>string ref date</returns>
        public static string UsaDateTimeFull(DateTime date)
        {
            return date.ToString(DateFormats.USA_DATE_TIME, CultureInfo.InvariantCulture);
        }
        /// <summary>
        /// Return date in format: <see cref="DateFormats.USA_DATE_TIME"/>
        /// </summary>
        /// <returns>date ref string</returns>
        public static DateTime UsaDateTimeFull(this string date)
        {
            return DateTime.ParseExact(date,
                    DateFormats.USA_DATE_TIME, CultureInfo.InvariantCulture);
        }
        /// <summary>
        /// Return true try string value parse in format: <see cref="DateFormats.USA_DATE_TIME"/>
        /// </summary>
        /// <returns>true or false</returns>
        public static bool TryUsaDateTimeFull(this string date, out DateTime outDate)
        {
            return DateTime.TryParseExact(date, DateFormats.USA_DATE_TIME,
                CultureInfo.InvariantCulture, DateTimeStyles.None, out outDate);
        }

        /// <summary>
        /// Return string with formar day of month in string
        /// </summary>
        /// <param name="date"></param>
        /// <param name="cultureInfo"></param>
        /// <returns></returns>
        public static string DayAndMonthString(this DateTime date, CultureInfo cultureInfo)
        {
            return
                date.Day > 9 ?
                string.Format("{0} de {1}", date.Day, date.ToString("MMMM", cultureInfo)) :
                string.Format("0{0} de {1}", date.Day, date.ToString("MMMM", cultureInfo));
        }

        /// <summary>
        /// Return only date part in string
        /// </summary>
        /// <param name="date"></param>
        /// <param name="cultureInfo"></param>
        /// <returns></returns>
        public static string OnlyDate(this string date)
        {
            return date.Substring(0, 10).Trim();
        }

        /// <summary>
        /// Return only time part in string
        /// </summary>
        /// <param name="date"></param>
        /// <param name="cultureInfo"></param>
        /// <returns></returns>
        public static string OnlyTime(this string date)
        {
            return date[date.LastIndexOf(" ")..].Trim();
        }
    }
}