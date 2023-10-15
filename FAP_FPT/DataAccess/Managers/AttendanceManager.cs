using FAP_FPT.DataAccess.Models;
using Microsoft.EntityFrameworkCore;

namespace FAP_FPT.DataAccess.Managers
{
    public class AttendanceManager
    {
        private FAP_FPTContext context = new FAP_FPTContext();

        public List<Attendance> GetAttendanceByStudentId(int? userId)
        {
            List<Attendance> attendances = context.Attendances.Where(s => s.Student.UserId == userId)
                .Include(p => p.Schedule).ThenInclude(c => c.CourseClass)
                .Include(p => p.Schedule).ThenInclude(c => c.Teacher)
                .Include(p => p.Schedule).ThenInclude(c => c.Slot)
                .ToList();
            return attendances;
        }

        public Attendance GetAttendanceById(int id)
        {
            return context.Attendances
            .Include(a => a.Schedule).ThenInclude(s => s.CourseClass)
            .Include(a => a.Schedule).ThenInclude(s => s.Teacher)
            .Include(a => a.Schedule).ThenInclude(s => s.Slot)
            .FirstOrDefault(s => s.Id == id);
        }

        public void updateStatusById( int id, string status)
        {
            Attendance a = GetAttendanceById(id);
            a.IsPresent = status;
            context.SaveChanges();
        }
        public List<Attendance> GetAttendancesByIdSchedule(int scheduleID)
        {
            List<Attendance> attendances = context.Attendances.Where(s => s.ScheduleId == scheduleID)
                .Include(p => p.Schedule).ThenInclude(c => c.CourseClass)
                .Include(p => p.Schedule).ThenInclude(c => c.Teacher)
                .Include(p => p.Schedule).ThenInclude(c => c.Slot)
                .Include(p => p.Student)
                .ToList();
            return attendances;
        }

        public List<Attendance> GetListAttendanceByStudent(int? id,DateTime startDate, DateTime endate )
        {
            List<Attendance> attendances = context.Attendances.Where(s => s.Student.UserId == id &&
            s.Schedule.Date >= startDate && s.Schedule.Date <= endate)
                .Include(p => p.Schedule).ThenInclude(c => c.CourseClass)
                .Include(p => p.Schedule).ThenInclude(c => c.Teacher)
                .Include(p => p.Schedule).ThenInclude(c => c.Slot)
                .ToList();
            return attendances;
        }

        public List<Attendance> getAttendancesReportByCourse(int? userId, string courseId)
        {
            return context.Attendances.Where(p => p.Student.UserId == userId && p.Schedule.CourseClass.CourseId == courseId)
                .Include(a => a.Schedule).ThenInclude(s => s.CourseClass)
                .Include(a => a.Schedule).ThenInclude(s => s.Teacher)
                .Include(a => a.Schedule).ThenInclude(s => s.Slot)
                .ToList();
        }


    }
}
