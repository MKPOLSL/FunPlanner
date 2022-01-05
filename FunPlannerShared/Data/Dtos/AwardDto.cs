using FunPlannerShared.Data.Enums;

namespace FunPlannerShared.Data.Dtos
{
    public class AwardDto
    {
        public Guid PersonId { get; set; }
        public Guid CalendarEventId { get; set; }
        public string? Text { get; set; }
        public AwardType? AwardType { get; set; }
    }
}
