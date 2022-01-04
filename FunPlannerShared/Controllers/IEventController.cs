using FunPlannerShared.Data.Dtos;
using FunPlannerShared.Data.Entities;
using Refit;

namespace FunPlannerShared.Controllers
{
    public interface IEventController
    {
        [Post("/event")]
        Task Post(CalendarEventCreateDto calendarEvent);
        
        [Post("/sign-me")]
        Task AssignPersonToEvent(Guid eventId, Guid personId);

        [Get("/event")]
        Task<ICollection<CalendarEvent>> Get();

        [Get("/upcoming")]
        Task<ICollection<UpcomingEventDto>> GetUpcoming();
    }
}
