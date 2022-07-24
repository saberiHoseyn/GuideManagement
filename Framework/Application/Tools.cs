using MD.PersianDateTime.Standard;
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
            var pc = new PersianDateTime(date);
            var str = pc.ToShortDateTimeString().ToString();
            return str;
        }


        public static string ToFarsiFull(this DateTime date)
        {
            var pc = new PersianDateTime(date);
            var str = pc.ToLongDateTimeString().ToString();

            return str;
        }
    }
}