using AutoMapper;
using FunPlannerShared.Data.Entities;

namespace FunPlannerApi.Automapper
{
    public class EventProfile : Profile
    {
        public EventProfile()
        {
            CreateMap<CalendarEventDto, CalendarEvent>();
        }
    }
}
