using FunPlannerShared.Data.Enums;

namespace FunPlannerShared.Data.Entities
{
    public class Person : IdentityEntity
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public int Points { get; set; }
        public Role Role { get; set; }

        public ICollection<CalendarEvent>? CreatedEvents { get; set; }
        public ICollection<EventParticipants>? ParticipatedEvents { get; set; }
        public ICollection<Note>? FromNotes { get; set; }
        public ICollection<Note>? ToNotes { get; set; }
        public ICollection<Award>? Awards { get; set; }
        public virtual Password Password { get; set; }
    }
}