using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Extensions
{
    public static class DateTimeExtensions
    {
        public static DateTime SetKindToUtc(this DateTime dateTime) {
            return dateTime.Kind == DateTimeKind.Utc ? dateTime : DateTime.SpecifyKind(dateTime, DateTimeKind.Utc);
        }
        public static DateTime GetStartOfWeek(this DateTime dateTime, DayOfWeek startOfWeek) {
            int diff = (7 + (dateTime.DayOfWeek - startOfWeek)) % 7;
            return dateTime.AddDays(-1 * diff).Date;
        }
        public static DateTime GetFirstDayOfMonth(this DateTime dateTime) {
            return new DateTime(dateTime.Year, dateTime.Month, 1);
        }
        public static DateTime GetLastDayOfMonth(this DateTime dateTime) {
            return new DateTime(dateTime.Year, dateTime.Month, DateTime.DaysInMonth(dateTime.Year, dateTime.Month));
        }
    }
}
