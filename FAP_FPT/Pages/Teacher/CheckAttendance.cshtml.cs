using FAP_FPT.DataAccess.Managers;
using FAP_FPT.DataAccess.Models;
using FAP_FPT.Hubs;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.SignalR;
using Newtonsoft.Json;

namespace FAP_FPT.Pages.Teacher
{
    public class CheckAttendanceModel : PageModel
    {
        private AttendanceManager attendanceManager = new AttendanceManager();

        private IHubContext<AttendanceHub> attendanceHub;

        public List<Attendance> listAttendances { get; set; }

        DateTime currentDate = DateTime.Now.Date;
        TimeSpan currentTime = DateTime.Now.TimeOfDay;

        public CheckAttendanceModel( IHubContext<AttendanceHub> attendanceHub)
        {
            this.attendanceHub = attendanceHub;

        }

        public IActionResult OnGet(int id)
        {
            setData(id);
            /*Schedule s = listAttendances.First().Schedule;
            if (s.Date != currentDate || (s.Slot.StartTime > currentTime || s.Slot.EndTime < currentTime))
            {
                return LocalRedirect("/Teacher/TeacherSchedule");
            } */   
                return Page();
        }

        public void setData(int id)
        {
            listAttendances = attendanceManager.GetAttendancesByIdSchedule(id);
        }

        public async Task<IActionResult> OnPost()
        {
            var formData = Request.Form;

            setData(Int32.Parse(formData["id"]));

            foreach (var attendance in listAttendances)
            {
                var studentStatus = formData["studentStatus_" + attendance.Id].ToString();
                attendanceManager.updateStatusById(attendance.Id, studentStatus);
            }
            var options = new JsonSerializerSettings
            {
                ReferenceLoopHandling = ReferenceLoopHandling.Ignore
            };
            var listAttendancesUpdate = JsonConvert.SerializeObject(listAttendances, options);
            await attendanceHub.Clients.All.SendAsync("attendanceSuccessful", listAttendancesUpdate);
            string message = "Check attendance successful!";
            TempData["message"] = message;
            return Page();
        }
    }
}
