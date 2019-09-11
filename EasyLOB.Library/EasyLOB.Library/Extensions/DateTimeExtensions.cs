using System;

namespace EasyLOB.Library
{
    /// <summary>
    /// DataTime Extensions.
    /// </summary>
    public static class DateTimeExtensions
    {
        /// <summary>
        /// Get first day of month.
        /// </summary>
        /// <param name="date">Date</param>
        /// <returns>Date</returns>
        public static DateTime FirstDayOfMonth(this DateTime date)
        {
            return new DateTime(date.Year, date.Month, 1);
        }

        /// <summary>
        /// Get last day of month.
        /// </summary>
        /// <param name="date">Date</param>
        /// <returns>Date</returns>
        public static DateTime LastDayOfMonth(this DateTime date)
        {
            return FirstDayOfMonth(date).AddMonths(1).AddDays(-1);
        }
    }
}