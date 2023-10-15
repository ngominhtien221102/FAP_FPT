using FAP_FPT.DataAccess.Managers;
using FAP_FPT.DataAccess.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using FAP_FPT.Helper;

namespace FAP_FPT.Pages.Teacher
{
    public class TeacherScheduleModel : PageModel
    {
        private ScheduleManager manager = new ScheduleManager();

        private AttendanceManager attendanceManager = new AttendanceManager();

        private TeacherManager teacherManager = new TeacherManager();

        private List<TimeSlot> timeSlots;

        DateTime currentDate = DateTime.Now;

        private DateTime monday;

        private DateTime sunday;
        public List<DateTime> weekDays { get; set; }

        public Schedule[,] timeTable = new Schedule[6, 7];

        public FAP_FPT.DataAccess.Models.Teacher CurrentTeacher { get; set; }

        public int Id { get; set; }

        public IActionResult OnGet(int? id)
        {
            int? userId = HttpContext.Session.GetInt32("userId");
            int? roleId = HttpContext.Session.GetInt32("roleId");
            if (userId == null || roleId == null || roleId != 2)
            {
                return LocalRedirect("/Login");
            }

            if (id == null)
            {
                monday = DetermineTime.MondayOfWeek(currentDate);
                sunday = DetermineTime.SundayOfWeek(currentDate);
                weekDays = GetWeekDays(monday);
                Id = 0;
            }
            else
            {
                currentDate = currentDate.AddDays((double)(id * 7));
                monday = DetermineTime.MondayOfWeek(currentDate);
                sunday = DetermineTime.SundayOfWeek(currentDate);
                weekDays = GetWeekDays(monday);
                Id = (int)id;
            }

            CurrentTeacher = teacherManager.GetTeacherByUserId(userId);
            List<Schedule> schedules = manager.GetTeacherSchedulesByDate(userId, monday, sunday);
            foreach (Schedule s in schedules)
            {
                switch (s.Date.DayOfWeek)
                {
                    case DayOfWeek.Monday:
                        timeTable[s.SlotId - 1, 0] = s;
                        break;
                    case DayOfWeek.Tuesday:
                        timeTable[s.SlotId - 1, 1] = s;
                        break;
                    case DayOfWeek.Wednesday:
                        timeTable[s.SlotId - 1, 2] = s;
                        break;
                    case DayOfWeek.Thursday:
                        timeTable[s.SlotId - 1, 3] = s;
                        break;
                    case DayOfWeek.Friday:
                        timeTable[s.SlotId - 1, 4] = s;
                        break;
                    case DayOfWeek.Saturday:
                        timeTable[s.SlotId - 1, 5] = s;
                        break;
                    case DayOfWeek.Sunday:
                        timeTable[s.SlotId - 1, 6] = s;
                        break;
                }
            }
            return Page();
        }

        private List<DateTime> GetWeekDays(DateTime monday)
        {
            List<DateTime> weekDays = new List<DateTime>();
            for (int i = 0; i < 7; i++)
            {
                weekDays.Add(monday.AddDays(i));
            }
            return weekDays;
        }
    }
}
