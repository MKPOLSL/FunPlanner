using FunPlannerShared.Data.Dtos;
using FunPlannerShared.Data.Entities;
using Refit;

namespace FunPlannerShared.Controllers
{
    public interface IEventController
    {
        [Post("/event")]
        Task Post(CalendarEventCreateDto calendarEvent);
        
        [Post("/event/sign-me")]
        Task AssignPersonToEvent(Guid eventId, Guid personId);

        [Get("/event")]
        Task<ICollection<CalendarEvent>> Get();

        [Get("/event/{id}/participants")]
        Task<CalendarEventDto> GetWithParticipants(Guid id);

        [Get("/event/calendar")]
        Task<ICollection<CalendarEventCalendarDto>> GetForCalendar();

        [Get("/event/upcoming")]
        Task<ICollection<UpcomingEventDto>> GetUpcoming();

        [Delete("/event/{id}")]
        Task Delete(Guid id);
    }
}
