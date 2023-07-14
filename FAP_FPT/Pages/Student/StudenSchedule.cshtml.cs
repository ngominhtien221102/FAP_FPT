
using FAP_FPT.DataAccess.Managers;
using FAP_FPT.DataAccess.Models;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace FAP_FPT.Pages.Student
{
    public class StudenScheduleModel : PageModel
    {
        private ScheduleManager manager = new ScheduleManager();

        private AttendanceManager manager1 = new AttendanceManager();

        private List<TimeSlot> timeSlots;

        public Schedule[,] timeTable = new Schedule[6, 7];

        public Attendance[,] timeTable1 = new Attendance[6, 7];

        public void OnGet()
        {
            List<Schedule> schedules = manager.GetStudentSchedules(3);
            List<Attendance> attendances = manager1.GetAttendanceByStudentId(3);
            foreach (Attendance s in attendances)
            {
                switch (s.Schedule.Date.DayOfWeek)
                {
                    case DayOfWeek.Monday:
                        timeTable1[s.Schedule.SlotId - 1, 0] = s;
                        break;
                    case DayOfWeek.Tuesday:
                        timeTable1[s.Schedule.SlotId - 1, 1] = s;
                        break;
                    case DayOfWeek.Wednesday:
                        timeTable1[s.Schedule.SlotId - 1, 2] = s;
                        break;
                    case DayOfWeek.Thursday:
                        timeTable1[s.Schedule.SlotId - 1, 3] = s;
                        break;
                    case DayOfWeek.Friday:
                        timeTable1[s.Schedule.SlotId - 1, 4] = s;
                        break;
                    case DayOfWeek.Saturday:
                        timeTable1[s.Schedule.SlotId - 1, 5] = s;
                        break;
                    case DayOfWeek.Sunday:
                        timeTable1[s.Schedule.SlotId - 1, 6] = s;
                        break;
                }
            }
        }
    }
}
