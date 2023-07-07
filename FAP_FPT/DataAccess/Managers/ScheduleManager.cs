using FAP_FPT.DataAccess.Models;

namespace FAP_FPT.DataAccess.Managers
{
    public class ScheduleManager
    {
        private FAP_FPTContext context;

        public List<Schedule> GetStudentSchedules(int studentId)
        {
            List<Schedule> schedules = context.Schedules.Where(s => s.Attendances.Any(a => a.StudentId == studentId)).ToList();
            return schedules;
        }

        static void Main(string[] args)
        {
            ScheduleManager s = new ScheduleManager();
            List<Schedule> schedules = s.GetStudentSchedules(3);
            foreach (Schedule item in schedules)
            {
                Console.WriteLine(item.ToString());
            }
        }

    }

    
}
