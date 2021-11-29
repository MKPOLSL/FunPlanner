using FunPlannerShared.Data.Entities;
using Microsoft.EntityFrameworkCore;

namespace FunPlannerApi.Data
{
    public class Context : DbContext
    {
        public Context(DbContextOptions<Context> options) : base(options) { }

        public DbSet<CalendarEvent> CalendarEvents { get; set; }
        public DbSet<Person> Persons { get; set; }
        public DbSet<EventParticipants> EventParticipants { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<EventParticipants>().HasKey(sc => new { sc.PersonId, sc.EventId });

            modelBuilder.Entity<CalendarEvent>()
            .HasOne<Person>(s => s.Creator)
            .WithMany(g => g.CreatedEvents)
            .HasForeignKey(s => s.CreatorId).OnDelete(DeleteBehavior.NoAction);

            modelBuilder.Entity<EventParticipants>()
                .HasOne<Person>(sc => sc.Person)
                .WithMany(s => s.ParticipatedEvents)
                .HasForeignKey(sc => sc.PersonId).OnDelete(DeleteBehavior.NoAction);

            modelBuilder.Entity<EventParticipants>()
                .HasOne<CalendarEvent>(sc => sc.CalendarEvent)
                .WithMany(s => s.Participants)
                .HasForeignKey(sc => sc.EventId).OnDelete(DeleteBehavior.NoAction);
        }
    }
}
