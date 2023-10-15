using System.Globalization;

namespace FAP_FPT.Helper
{
    public class DetermineTime
    {
        public static DateTime MondayOfWeek(DateTime dateTime)
        {
            DayOfWeek currentDayOfWeek = dateTime.DayOfWeek;

            int daysToMonday = (currentDayOfWeek - DayOfWeek.Monday + 7) % 7;
            return dateTime.AddDays(-daysToMonday);
        }

        public static DateTime SundayOfWeek(DateTime dateTime)
        {
            DayOfWeek currentDayOfWeek = dateTime.DayOfWeek;
            CultureInfo cultureInfo = CultureInfo.CurrentCulture;
            DayOfWeek firstDayOfWeek = cultureInfo.DateTimeFormat.FirstDayOfWeek;
            int daysToAdd = ((int)firstDayOfWeek - (int)currentDayOfWeek + 7) % 7;
            return dateTime.AddDays(daysToAdd);
        }
    }
}
