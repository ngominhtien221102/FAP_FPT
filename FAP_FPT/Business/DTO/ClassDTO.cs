using FAP_FPT.DataAccess.Models;

namespace FAP_FPT.Business.DTO
{
    public class ClassDTO
    {
        public ClassDTO()
        {
            CourseClasses = new HashSet<CourseClassDTO>();
            Students = new HashSet<StudentDTO>();
        }

        public string ClassId { get; set; } = null!;
        public int Capacity { get; set; }

        public virtual ICollection<CourseClassDTO> CourseClasses { get; set; }
        public virtual ICollection<StudentDTO> Students { get; set; }
    }
}
