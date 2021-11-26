using FunPlannerShared.Data.Entities;
using Microsoft.EntityFrameworkCore;

namespace FunPlannerApi.Data
{
    public class Context : DbContext
    {
        public Context(DbContextOptions<Context> options) : base(options) { }

        public DbSet<CalendarEvent> CalendarEvents { get; set; }
        public DbSet<Person> Persons { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

        }
    }
}
