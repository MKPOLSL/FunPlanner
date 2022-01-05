using FunPlannerShared.Data.Entities;

namespace FunPlannerShared.Data.Dtos
{
    public class CalendarEventCalendarDto : IdentityEntity
    {
        public string Name { get; set; }
        public DateTime Start { get; set; }
        public DateTime End { get; set; }
    }
}
