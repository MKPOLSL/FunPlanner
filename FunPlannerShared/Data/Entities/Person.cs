﻿namespace FunPlannerShared.Data.Entities
{
    public class Person : IdentityEntity
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public int Points { get; set; }

        public ICollection<CalendarEvent>? CreatedEvents { get; set; }
        public ICollection<EventParticipants>? ParticipatedEvents { get; set; }
        public virtual Password Password { get; set; }
    }
}