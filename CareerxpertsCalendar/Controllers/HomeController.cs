using CareerxpertsCalendar.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using System.Globalization;

namespace CareerxpertsCalendar.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index(int year = 0)
        {
            if (year == 0) year = DateTime.Now.Year;

            var model = GenerateCalendar(year);
            return View(model);
        }

        private List<MonthModel> GenerateCalendar(int year)
        {
            var months = new List<MonthModel>();
            for (int month = 1; month <= 12; month++)
            {
                months.Add(new MonthModel
                {
                    Name = CultureInfo.CurrentCulture.DateTimeFormat.GetMonthName(month),
                    Year = year,
                    Days = GenerateDays(year, month)
                });
            }
            return months;
        }

        private List<DayModel> GenerateDays(int year, int month)
        {
            var days = new List<DayModel>();
            DateTime firstDay = new DateTime(year, month, 1);
            int totalDays = DateTime.DaysInMonth(year, month);

            for (int i = 1; i <= totalDays; i++)
            {
                days.Add(new DayModel
                {
                    Date = i,
                    DayName = firstDay.AddDays(i - 1).DayOfWeek.ToString()
                });
            }
            return days;
        }
      


        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
