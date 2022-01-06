using FunPlannerShared.Data.Entities;

namespace FunPlannerShared.Data.Dtos
{
    public class CalendarEventDto : IdentityEntity
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public DateTime Start { get; set; }
        public DateTime End { get; set; }

        public AwardDto? Award { get; set; }

        public bool EventRegistration { get; set; }
        public bool IsLimited { get; set; }
        public int? Limit { get; set; }
        public string Place { get; set; }
        public ICollection<PersonDto> Participants { get; set; }
    }
}
