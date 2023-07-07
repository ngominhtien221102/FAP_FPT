﻿using System;
using System.Collections.Generic;

namespace FAP_FPT.DataAccess.Models
{
    public partial class Student
    {
        public Student()
        {
            Attendances = new HashSet<Attendance>();
        }

        public int Id { get; set; }
        public string StudentCode { get; set; } = null!;
        public string FullName { get; set; } = null!;
        public DateTime Dob { get; set; }
        public bool Gender { get; set; }
        public string Phone { get; set; } = null!;
        public string Avatar { get; set; } = null!;
        public string Major { get; set; } = null!;
        public string? IdCard { get; set; }
        public int CurrentTermNo { get; set; }
        public string? ClassId { get; set; }
        public int? UserId { get; set; }

        public virtual Class? Class { get; set; }
        public virtual User? User { get; set; }
        public virtual ICollection<Attendance> Attendances { get; set; }
    }
}
