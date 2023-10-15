using FAP_FPT.DataAccess.Models;
using Microsoft.EntityFrameworkCore;

namespace FAP_FPT.DataAccess.Managers
{
    public class ScheduleManager
    {
        private FAP_FPTContext context = new FAP_FPTContext();

        public List<Schedule> GetStudentSchedules(int studentId)
        {
            List<Schedule> schedules = context.Schedules.Where(s => s.Attendances.Any(a => a.StudentId == studentId))
                .Include(p => p.CourseClass).ThenInclude(c => c.Course)
                .Include(p => p.Teacher)
                .Include(p => p.Room)
                .Include(p => p.Slot)
                .ToList();
            return schedules;
        }

        public List<Schedule> GetTeacherSchedules(int? userId)
        {   
            List<Schedule> schedules = context.Schedules.Where(s => s.Teacher.UserId == userId)
                .Include(p => p.CourseClass).ThenInclude(c => c.Course)
                .Include(p => p.Attendances)
                .Include(p => p.Room)
                .Include(p => p.Slot)
                .ToList();
            return schedules;
        }


        public List<Schedule> GetTeacherSchedulesByDate(int? userId, DateTime startDate, DateTime endDate)
        {
            List<Schedule> schedules = context.Schedules.Where(s => s.Teacher.UserId == userId
            && s.Date >= startDate && s.Date <= endDate)
                .Include(p => p.CourseClass).ThenInclude(c => c.Course)
                .Include(p => p.Attendances)
                .Include(p => p.Room)
                .Include(p => p.Slot)
                .ToList();
            return schedules;
        }
    }

    
}
