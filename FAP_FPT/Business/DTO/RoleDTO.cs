using FAP_FPT.DataAccess.Models;

namespace FAP_FPT.Business.DTO
{
    public class RoleDTO
    {
        public RoleDTO()
        {
            Users = new HashSet<UserDTO>();
        }

        public int RoleId { get; set; }
        public string RoleName { get; set; } = null!;
        public string? Description { get; set; }

        public virtual ICollection<UserDTO> Users { get; set; }

    }
}
