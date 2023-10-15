using FAP_FPT.DataAccess.Models;
using Microsoft.EntityFrameworkCore;

namespace FAP_FPT.DataAccess.Managers
{
    public class UserManager
    {
        private FAP_FPTContext context;

        public UserManager(FAP_FPTContext context)
        {
            this.context = context;
        }

        public List<User> getListUsers()
        {
            return context.Users
                .Include(p => p.Role).ToList();
        }

        public User GetUser(int userId)
        {
            return context.Users.FirstOrDefault(p => p.Id == userId);
        }

        public User GetUserByEmail(string email)
        {
            return context.Users.Include(p => p.Teachers)
                .Include(p => p.Students)
                .FirstOrDefault(p => p.Email == email);
        }
    }
}
