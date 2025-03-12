namespace CareerxpertsCalendar.Models
{
    public class MonthModel
    {
        public string Name { get; set; }
        public int Year { get; set; }
        public List<DayModel> Days { get; set; }
    }
    public class DayModel
    {
        public int Date { get; set; }
        public string DayName { get; set; }
    }
}
