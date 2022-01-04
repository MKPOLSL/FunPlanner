using FunPlannerShared.Data.Enums;

namespace FunPlannerShared.Data.Entities
{
    public class Award : IdentityEntity
    {
        public Guid PersonId { get; set; }
        public Person Person { get; set; }
        public Guid CalendarEventId { get; set; }
        public CalendarEvent CalendarEvent { get; set; }
        public string? Text { get; set; }
        public AwardType? AwardType { get; set; }
    }
}
