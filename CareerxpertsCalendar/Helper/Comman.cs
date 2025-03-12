using CareerxpertsCalendar.Models;

namespace CareerxpertsCalendar.Helper
{
    public static class Comman
    {
        public static MonthModel? GetMonthsStartingOnDay(int dayOfWeek, List<MonthModel> months)
        {
            if (months == null || months.Count == 0)
                return null;

            if (dayOfWeek == 7)
            {
                var montha = months.FirstOrDefault(m => m.FirstDayOfWeek == 0);
                if (montha != null)
                {
                    months.Remove(montha);
                    return montha;
                }
            }

            var month = months.FirstOrDefault(m => m.FirstDayOfWeek == dayOfWeek);
            if (month != null)
            {
                months.Remove(month);
                return month;
            }

            return null; // Return empty string instead of error when list is exhausted
        }

    }
}
