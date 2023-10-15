
using FAP_FPT.DataAccess.Managers;
using FAP_FPT.DataAccess.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using FAP_FPT.Helper;
using Microsoft.AspNetCore.Components.Server;
using System;

namespace FAP_FPT.Pages.Student
{
    public class StudenScheduleModel : PageModel
    {
        
        private AttendanceManager attendanceManager = new AttendanceManager();

        private StudentManger studentManger = new StudentManger();

        private List<TimeSlot> timeSlots;

        public Attendance[,] timeTable1 = new Attendance[6, 7];

        public int Id { get; set; }

        DateTime currentDate = DateTime.Now;

        private DateTime monday;

        private DateTime sunday;

        public List<DateTime> weekDays { get; set; }

        public FAP_FPT.DataAccess.Models.Student CurrentStudent { get; set; }
        public IActionResult OnGet(int? id)
        {
            int? userId = HttpContext.Session.GetInt32("userId");
            int? roleId = HttpContext.Session.GetInt32("roleId");
            if (userId == null || roleId == null || roleId != 3)
            {
                return LocalRedirect("/Login");
            }

            if(id == null)
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
            CurrentStudent = studentManger.GetStudentByUserId(userId);
            List<Attendance> attendances = attendanceManager.GetListAttendanceByStudent(userId,monday,sunday);
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
