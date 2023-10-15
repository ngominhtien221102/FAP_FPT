using FAP_FPT.DataAccess.Models;

namespace FAP_FPT.Business.DTO
{
    public class RoomDTO
    {
        public RoomDTO()
        {
            Schedules = new HashSet<ScheduleDTO>();
        }

        public string RoomId { get; set; } = null!;
        public bool IsAvalible { get; set; }

        public virtual ICollection<ScheduleDTO> Schedules { get; set; }
    }
}
