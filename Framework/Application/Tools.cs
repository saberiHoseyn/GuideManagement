using System;
using System.Globalization;

namespace Framework.Application
{
    public static class Tools
    {
        public static string ToFarsi(this DateTime? date)
        {
            try
            {
                if (date != null) return date.Value.ToFarsi();
            }
            catch (Exception)
            {
                return "";
            }

            return "";
        }

        public static string ToFarsi(this DateTime date)
        {
            if (date == new DateTime()) return "";
            var pc = new PersianCalendar();
            return $"{pc.GetYear(date)}/{pc.GetMonth(date):00}/{pc.GetDayOfMonth(date):00}";
        }


        public static string ToFarsiFull(this DateTime date)
        {
            var pc = new PersianCalendar();
            return
                $"{pc.GetYear(date)}/{pc.GetMonth(date):00}/{pc.GetDayOfMonth(date):00} {date.Hour:00}:{date.Minute:00}:{date.Second:00}";
        }
    }
}