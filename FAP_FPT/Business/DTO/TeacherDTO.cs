using FAP_FPT.DataAccess.Models;

namespace FAP_FPT.Business.DTO
{
    public class TeacherDTO
    {
        public TeacherDTO()
        {
            CourseClasses = new HashSet<CourseClassDTO>();
            Schedules = new HashSet<ScheduleDTO>();
        }

        public int Id { get; set; }
        public string TeacherCode { get; set; } = null!;
        public string FullName { get; set; } = null!;
        public DateTime Dob { get; set; }
        public bool Gender { get; set; }
        public string Phone { get; set; } = null!;
        public string Major { get; set; } = null!;
        public int? UserId { get; set; }

        public virtual UserDTO? User { get; set; }
        public virtual ICollection<CourseClassDTO> CourseClasses { get; set; }
        public virtual ICollection<ScheduleDTO> Schedules { get; set; }
    }
}
