using System;
using System.Collections.Generic;
using System.Linq;

namespace splendor.net5.core.tools.date
{
    public static class PeruvianDateExtensions
    {
        public static DateTime CurrentPeruvianLaborDate(this DateTime current, IEnumerable<DateTime> holidays)
        {
            while (current.DayOfWeek == DayOfWeek.Saturday
                || current.DayOfWeek == DayOfWeek.Sunday
                || (holidays != null && holidays.Contains(current.Date)))
            {
                current = current.AddDays(1);
            }
            return current;
        }

        public static DateTime AddPeruvianLaborDate(DateTime current, int days, IEnumerable<DateTime> holidays = null)
        {
            var sign = Math.Sign(days);
            var unsignedDays = Math.Abs(days);
            for (var i = 0; i < unsignedDays; i++)
            {
                do
                {
                    current = current.AddDays(sign);
                }
                while (current.DayOfWeek == DayOfWeek.Saturday
                    || current.DayOfWeek == DayOfWeek.Sunday
                    || (holidays != null && holidays.Contains(current.Date))
                    );
            }
            return current;
        }

        public static List<int> YearsFrom(int xyear)
        {
            List<int> years = new();
            for (int i = xyear; i <= DateTime.UtcNow.AmericaLima().Year; i++)
            {
                years.Add(i);
            }
            return years;
        }

        public static List<int> YearsTo(int xyear)
        {
            List<int> years = new();
            for (int i = DateTime.UtcNow.AmericaLima().Year; i >= xyear; i--)
            {
                years.Add(i);
            }
            return years;
        }

        public static bool IsBirthDay(DateTime birthDate)
        {
            var current = DateTime.UtcNow.AmericaLima();
            return current.Month == birthDate.Month && current.Day == birthDate.Day;
        }

        public static int CurrentYear()
        {
            return DateTime.UtcNow.AmericaLima().Year;
        }

        public static bool DateIsInLastWeek(DateTime date)
        {
            return date.Day >= (DateTime.DaysInMonth(date.Year, date.Month) - 7);
        }

        public static DateTime LastDate(int year, int month)
        {
            return new DateTime(year, month, DateTime.DaysInMonth(year, month));
        }

        public static Month CurrentMonth()
        {
            int currentMonth = DateTime.UtcNow.AmericaLima().Month;
            return Months.Month(currentMonth);
        }

        public static DateTime MaxDatePlaning()
        {
            var current = DateTime.UtcNow.AmericaLima();
            if (DateIsInLastWeek(current))
            {
                var year = current.Year;
                var month = current.Month;
                if (month == 12)
                {
                    year++;
                    month = 1;
                }
                else
                {
                    month++;
                }
                return LastDate(year, month);
            }
            else
            {
                return LastDate(current.Year, current.Month);
            }
        }
    }
}