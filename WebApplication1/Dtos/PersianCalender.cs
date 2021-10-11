using System;
using System.Globalization;

namespace WebApplication1.Dtos
{
    public static class PersianCalender
    {
        public static string ToPersianDate(this DateTimeOffset input)
        {
            var pc = new System.Globalization.PersianCalendar();
            return $"{pc.GetYear(input.DateTime)}/{pc.GetMonth(input.DateTime)}/{pc.GetDayOfMonth(input.DateTime)}";
        }
    }
}
