using FAP_FPT.DataAccess.Models;

namespace FAP_FPT.DataAccess.Managers
{
    public class StudentManger
    {
        private FAP_FPTContext context = new FAP_FPTContext();

        public Student GetStudentByUserId(int? id)
        {
            return context.Students.FirstOrDefault(p => p.UserId == id);
        }
    }
}
