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

    }

    
}
