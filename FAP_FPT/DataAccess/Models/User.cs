using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;

namespace FAP_FPT.DataAccess.Models
{
    public partial class User:IdentityUser
    {
        public User()
        {
            Students = new HashSet<Student>();
            Teachers = new HashSet<Teacher>();
        }

        public int Id { get; set; }
        public int RoleId { get; set; }
        public string? Email { get; set; }

        public virtual Role Role { get; set; } = null!;
        public virtual ICollection<Student> Students { get; set; }
        public virtual ICollection<Teacher> Teachers { get; set; }
    }
}
