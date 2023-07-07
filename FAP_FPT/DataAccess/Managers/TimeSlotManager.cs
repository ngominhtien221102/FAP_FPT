using FAP_FPT.DataAccess.Models;

namespace FAP_FPT.DataAccess.Managers
{
    public class TimeSlotManager
    {
        private FAP_FPTContext context;

        public List<TimeSlot> getTimeSlots()
        {
            List<TimeSlot> slots = context.TimeSlots.ToList();
            return slots;
        }

        public List<TimeSlot> getTimeSlotsSchedule(int StudentId)
        {
            List<TimeSlot> slots = context.TimeSlots.ToList();
            return slots;
        }
    }
}
