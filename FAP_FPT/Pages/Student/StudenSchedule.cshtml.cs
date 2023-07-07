using FAP_FPT.DataAccess.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace FAP_FPT.Pages.Student
{
    public class StudenScheduleModel : PageModel
    {   
        private List<TimeSlot> timeSlots;


        public void OnGet()
        {
        }
    }
}
