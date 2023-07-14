using FAP_FPT.DataAccess.Models;
using Microsoft.EntityFrameworkCore;

namespace FAP_FPT.DataAccess.Managers
{
    public class CourseClassManager
    {
        private FAP_FPTContext context = new FAP_FPTContext();

        public List<CourseClass> getCourseClassesByStudentId(int id)
        {
            List<CourseClass> courseClasses = context.CourseClasses
            .Where(cc => cc.Class.Students.Any(s => s.UserId == id))
            .ToList();
            return courseClasses;
        }
    }
}
