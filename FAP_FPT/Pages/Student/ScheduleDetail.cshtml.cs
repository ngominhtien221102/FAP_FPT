using FAP_FPT.DataAccess.Managers;
using FAP_FPT.DataAccess.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace FAP_FPT.Pages.Student
{
    public class ScheduleDetailModel : PageModel
    {
        private AttendanceManager manager = new AttendanceManager();

        public Attendance attendance;
        public IActionResult OnGet(string id)
        {
            int? userId = HttpContext.Session.GetInt32("userId");
            int? roleId = HttpContext.Session.GetInt32("roleId");
            if (userId == null || roleId == null || roleId != 3)
            {
                return LocalRedirect("/Login");
            }
            int attendanceID = Int32.Parse(id);
            attendance = manager.GetAttendanceById(attendanceID);
            return Page();
        }
    }
}
