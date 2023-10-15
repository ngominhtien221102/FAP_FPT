using FAP_FPT.DataAccess.Models;

namespace FAP_FPT.Business.DTO
{
    public class TimeSlotDTO
    {
        public TimeSlotDTO()
        {
            Schedules = new HashSet<ScheduleDTO>();
        }

        public int SlotId { get; set; }
        public TimeSpan StartTime { get; set; }
        public TimeSpan EndTime { get; set; }

        public virtual ICollection<ScheduleDTO> Schedules { get; set; }
    }
}
