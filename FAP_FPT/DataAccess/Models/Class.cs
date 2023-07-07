using System;
using System.Collections.Generic;

namespace FAP_FPT.DataAccess.Models
{
    public partial class Class
    {
        public Class()
        {
            CourseClasses = new HashSet<CourseClass>();
            Students = new HashSet<Student>();
        }

        public string ClassId { get; set; } = null!;
        public int Capacity { get; set; }

        public virtual ICollection<CourseClass> CourseClasses { get; set; }
        public virtual ICollection<Student> Students { get; set; }
    }
}
