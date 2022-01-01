namespace FunPlannerShared.Data.Entities
{
    public class UpcomingEventDto : IdentityEntity
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public DateTime Start { get; set; }
        public DateTime End { get; set; }
        public Guid CreatorId { get; set; }
        public bool EventRegistration { get; set; }
        public bool IsLimited { get; set; }
        public int? Limit { get; set; }
        public string Place { get; set; }
        public int Participants { get; set; }
        public ICollection<Guid> ParticipantsId { get; set; }

        public bool ShowDetails { get; set; } = false;
    }
}
