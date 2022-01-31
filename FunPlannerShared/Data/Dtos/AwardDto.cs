using FunPlannerShared.Data.Enums;

namespace FunPlannerShared.Data.Dtos
{
    public class AwardDto
    {
        public Guid Id { get; set; }
        public Guid PersonId { get; set; }
        public Guid CalendarEventId { get; set; }
        public string CalendarEventName { get; set; }
        public string? Text { get; set; }
        public AwardType? AwardType { get; set; }
    }
}
