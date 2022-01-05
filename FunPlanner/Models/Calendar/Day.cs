using FunPlannerShared.Data.Dtos;

namespace FunPlanner.Models.Calendar
{
    public class Day
    {
        public int DayNumber { get; set; }
        public DateTime Date { get; set; }
        public bool IsEmpty { get; set; }
        public ICollection<CalendarEventCalendarDto> Events { get; set; }
    }
}
