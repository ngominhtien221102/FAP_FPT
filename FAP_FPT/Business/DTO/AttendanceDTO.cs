using FAP_FPT.DataAccess.Models;

namespace FAP_FPT.Business.DTO
{
    public class AttendanceDTO
    {
        public int Id { get; set; }
        public int ScheduleId { get; set; }
        public int StudentId { get; set; }
        public string? IsPresent { get; set; }

        public virtual ScheduleDTO Schedule { get; set; } = null!;
        public virtual StudentDTO Student { get; set; } = null!;
    }
}
