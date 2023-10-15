using FAP_FPT.DataAccess.Models;

namespace FAP_FPT.Business.DTO
{
    public class CourseClassDTO
    {
        public CourseClassDTO()
        {
            Schedules = new HashSet<ScheduleDTO>();
        }

        public int Id { get; set; }
        public string ClassId { get; set; } = null!;
        public string CourseId { get; set; } = null!;
        public int? TeacherId { get; set; }
        public DateTime? StartDate { get; set; }
        public DateTime? EndDate { get; set; }

        public virtual ClassDTO Class { get; set; } = null!;
        public virtual CourseDTO Course { get; set; } = null!;
        public virtual TeacherDTO? Teacher { get; set; }
        public virtual ICollection<ScheduleDTO> Schedules { get; set; }
    }
}
