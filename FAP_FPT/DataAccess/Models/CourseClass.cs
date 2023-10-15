using System;
using System.Collections.Generic;

namespace FAP_FPT.DataAccess.Models
{
    public partial class CourseClass
    {
        public CourseClass()
        {
            Schedules = new HashSet<Schedule>();
        }

        public int Id { get; set; }
        public string ClassId { get; set; } = null!;
        public string CourseId { get; set; } = null!;
        public int? TeacherId { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }

        public virtual Class Class { get; set; } = null!;
        public virtual Course Course { get; set; } = null!;
        public virtual Teacher? Teacher { get; set; }
        public virtual ICollection<Schedule> Schedules { get; set; }
    }
}
