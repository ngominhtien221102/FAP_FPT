using FAP_FPT.DataAccess.Models;

namespace FAP_FPT.Business.DTO
{
    public class ScheduleDTO
    {
        public ScheduleDTO()
        {
            Attendances = new HashSet<AttendanceDTO>();
        }

        public int Id { get; set; }
        public int SlotId { get; set; }
        public DateTime Date { get; set; }
        public int CourseClassId { get; set; }
        public string RoomId { get; set; } = null!;
        public int TeacherId { get; set; }

        public virtual CourseClassDTO CourseClass { get; set; } = null!;
        public virtual RoomDTO Room { get; set; } = null!;
        public virtual TimeSlotDTO Slot { get; set; } = null!;
        public virtual TeacherDTO Teacher { get; set; } = null!;
        public virtual ICollection<AttendanceDTO> Attendances { get; set; }
    }
}
