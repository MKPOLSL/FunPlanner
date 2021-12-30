using FunPlannerShared.Data.Entities;
using Refit;

namespace FunPlannerShared.Controllers
{
    public interface IEventController
    {
        [Post("/Event")]
        Task Post(CalendarEventDto calendarEvent);

        [Get("/Event")]
        Task<ICollection<CalendarEvent>> Get();
    }
}
