using System;
using System.Collections.Generic;

namespace FAP_FPT.DataAccess.Models
{
    public partial class Course
    {
        public Course()
        {
            CourseClasses = new HashSet<CourseClass>();
        }

        public string CourseId { get; set; } = null!;
        public string CourseName { get; set; } = null!;

        public virtual ICollection<CourseClass> CourseClasses { get; set; }
    }
}
