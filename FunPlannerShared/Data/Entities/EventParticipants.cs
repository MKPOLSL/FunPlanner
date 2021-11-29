namespace FunPlannerShared.Data.Entities
{
    public class EventParticipants
    {
        public Guid PersonId { get; set; }
        public Person Person { get; set; }

        public Guid EventId { get; set; }
        public CalendarEvent CalendarEvent { get; set; }
    }
}
