namespace FunPlannerShared.Data.Entities
{
    public class CalendarEvent : IdentityEntity
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public DateTime Start { get; set; }
        public DateTime End { get; set; }

        public Guid CreatorId { get; set; }
        public Person Creator { get; set; }
        public ICollection<EventParticipants>? Participants { get; set; }
        public virtual Award? Award { get; set; }

        public bool EventRegistration { get; set; } = false;
        public bool IsLimited { get; set; } = false;
        public int? Limit { get; set; } = 10;
        public string Place { get; set; }

        public CalendarEvent()
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
