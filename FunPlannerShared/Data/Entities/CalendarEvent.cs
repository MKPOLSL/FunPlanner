namespace FunPlannerShared.Data.Entities
{
    public class CalendarEvent : IdentityEntity
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public DateTime Start { get; set; }
        public DateTime End { get; set; }
    }
}
