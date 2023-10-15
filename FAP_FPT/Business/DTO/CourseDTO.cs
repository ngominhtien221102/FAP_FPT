using FAP_FPT.DataAccess.Models;

namespace FAP_FPT.Business.DTO
{
    public class CourseDTO
    {
        public CourseDTO()
        {
            CourseClasses = new HashSet<CourseClassDTO>();
        }

        public string CourseId { get; set; } = null!;
        public string CourseName { get; set; } = null!;

        public virtual ICollection<CourseClassDTO> CourseClasses { get; set; }
    }
}
