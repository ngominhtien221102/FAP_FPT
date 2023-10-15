using FAP_FPT.DataAccess.Models;

namespace FAP_FPT.Business.DTO
{
    public class StudentDTO
    {
        public StudentDTO()
        {
            Attendances = new HashSet<AttendanceDTO>();
        }

        public int Id { get; set; }
        public string StudentCode { get; set; } = null!;
        public string FullName { get; set; } = null!;
        public DateTime Dob { get; set; }
        public bool Gender { get; set; }
        public string Phone { get; set; } = null!;
        public string Avatar { get; set; } = null!;
        public string Major { get; set; } = null!;
        public string? IdCard { get; set; }
        public int CurrentTermNo { get; set; }
        public string? ClassId { get; set; }
        public int? UserId { get; set; }

        public virtual ClassDTO? Class { get; set; }
        public virtual UserDTO? User { get; set; }
        public virtual ICollection<AttendanceDTO> Attendances { get; set; }
    }
}
