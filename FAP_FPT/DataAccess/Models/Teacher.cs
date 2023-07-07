using System;
using System.Collections.Generic;

namespace FAP_FPT.DataAccess.Models
{
    public partial class Teacher
    {
        public Teacher()
        {
            CourseClasses = new HashSet<CourseClass>();
            Schedules = new HashSet<Schedule>();
        }

        public int Id { get; set; }
        public string TeacherCode { get; set; } = null!;
        public string FullName { get; set; } = null!;
        public DateTime Dob { get; set; }
        public bool Gender { get; set; }
        public string Phone { get; set; } = null!;
        public string Major { get; set; } = null!;
        public int? UserId { get; set; }

        public virtual User? User { get; set; }
        public virtual ICollection<CourseClass> CourseClasses { get; set; }
        public virtual ICollection<Schedule> Schedules { get; set; }
    }
}
