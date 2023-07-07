using System;
using System.Collections.Generic;

namespace FAP_FPT.DataAccess.Models
{
    public partial class Room
    {
        public Room()
        {
            Schedules = new HashSet<Schedule>();
        }

        public string RoomId { get; set; } = null!;
        public bool IsAvalible { get; set; }

        public virtual ICollection<Schedule> Schedules { get; set; }
    }
}
