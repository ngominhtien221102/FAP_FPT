using FAP_FPT.DataAccess.Managers;
using FAP_FPT.DataAccess.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace FAP_FPT.Pages.Student
{
    public class ReportAttendanceStudentModel : PageModel
    {
        private AttendanceManager attendanceManager = new AttendanceManager();

        private CourseClassManager courseClassManager = new CourseClassManager();

        public List<Attendance> getListAttendance = new List<Attendance>();

        public List<CourseClass> getCourseClassByUser;
        
        

        public IActionResult OnGet(string course, int userId)
        {
            int? id = HttpContext.Session.GetInt32("userId");
            int? roleId = HttpContext.Session.GetInt32("roleId");
            if (id == null || roleId == null || roleId != 3)
            {
                return LocalRedirect("/Login");
            }    
            getCourseClassByUser = courseClassManager.getCourseClassesByStudentId(id);
            if(course != null)
            {
                getListAttendance = attendanceManager.getAttendancesReportByCourse(id, course);
            }
            return Page();
            

        }

       

    }
}
