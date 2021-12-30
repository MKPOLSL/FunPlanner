namespace FunPlannerShared.Data.Entities
{
    public class CalendarEventDto : IdentityEntity
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public DateTime Start { get; set; }
        public DateTime End { get; set; }
        public Guid CreatorId { get; set; }
        public bool EventRegistration { get; set; } = false;
        public bool IsLimited { get; set; } = false;
        public int? Limit { get; set; } = 10;
        public string Place { get; set; }

        public CalendarEventDto()
        {
            Id = Guid.NewGuid();
            Name = "Nazwa";
            Description = "Opis";
            Place = "Miejsce";
            Start = DateTime.Now;
            End = DateTime.Now;
        }
    }
}
