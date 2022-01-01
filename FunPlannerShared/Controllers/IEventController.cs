using FunPlannerShared.Data.Entities;
using Refit;

namespace FunPlannerShared.Controllers
{
    public interface IEventController
    {
        [Post("/Event")]
        Task Post(CalendarEventCreateDto calendarEvent);
        
        [Post("/Sign-me")]
        Task AssignPersonToEvent(Guid eventId, Guid personId);

        [Get("/Event")]
        Task<ICollection<CalendarEvent>> Get();

        [Get("/Upcoming")]
        Task<ICollection<UpcomingEventDto>> GetUpcoming();
    }
}
