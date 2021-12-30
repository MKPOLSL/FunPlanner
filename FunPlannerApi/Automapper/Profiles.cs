using AutoMapper;
using FunPlannerShared.Data.Entities;

namespace FunPlannerApi.Automapper
{
    public class Profiles : Profile
    {
        public Profiles()
        {
            CreateMap<CalendarEventDto, CalendarEvent>();
        }
    }
}
