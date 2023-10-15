using FAP_FPT.DataAccess.Models;

namespace FAP_FPT.Business.DTO
{
    public class UserDTO
    {
        public UserDTO()
        {
            Students = new HashSet<StudentDTO>();
            Teachers = new HashSet<TeacherDTO>();
        }

        public int Id { get; set; }
        public int RoleId { get; set; }
        public string? Email { get; set; }

        public virtual RoleDTO Role { get; set; } = null!;
        public virtual ICollection<StudentDTO> Students { get; set; }
        public virtual ICollection<TeacherDTO> Teachers { get; set; }
    }
}
