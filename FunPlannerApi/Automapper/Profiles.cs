using AutoMapper;
using FunPlannerShared.Data.Entities;

namespace FunPlannerApi.Automapper
{
    public class Profiles : Profile
    {
        public Profiles()
        {
            CreateMap<CalendarEventCreateDto, CalendarEvent>();

            CreateMap<CalendarEvent, UpcomingEventDto>()
                .ForMember(dest => dest.Participants, opt => opt.MapFrom(e => e.Participants.Count()))
                .ForMember(dest => dest.ParticipantsId, opt => opt.MapFrom(e => e.Participants.Select(p => p.PersonId)));
            CreateMap<ICollection<UpcomingEventDto>, ICollection<CalendarEvent>>();
        }
    }
}
