using FAP_FPT.DataAccess.Models;

namespace FAP_FPT.DataAccess.Managers
{
    public class TeacherManager
    {
        private FAP_FPTContext context = new FAP_FPTContext();

        public Teacher GetTeacherByUserId(int? id)
        {
            return context.Teachers.FirstOrDefault(p => p.UserId == id);
        }
    }
}
