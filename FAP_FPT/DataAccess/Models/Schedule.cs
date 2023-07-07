using System;
using System.Collections.Generic;

namespace FAP_FPT.DataAccess.Models
{
    public partial class Schedule
    {
        public Schedule()
        {
            Attendances = new HashSet<Attendance>();
        }

        public int Id { get; set; }
        public int SlotId { get; set; }
        public DateTime Date { get; set; }
        public int CourseClassId { get; set; }
        public string RoomId { get; set; } = null!;
        public int TeacherId { get; set; }

        public virtual CourseClass CourseClass { get; set; } = null!;
        public virtual Room Room { get; set; } = null!;
        public virtual TimeSlot Slot { get; set; } = null!;
        public virtual Teacher Teacher { get; set; } = null!;
        public virtual ICollection<Attendance> Attendances { get; set; }
    }
}
