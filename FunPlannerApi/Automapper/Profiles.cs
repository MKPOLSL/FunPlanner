using AutoMapper;
using FunPlannerShared.Data.Dtos;
using FunPlannerShared.Data.Entities;

namespace FunPlannerApi.Automapper
{
    public class Profiles : Profile
    {
        public Profiles()
        {
            CreateMap<CalendarEventCreateDto, CalendarEvent>();

            CreateMap<CalendarEvent, CalendarEventDto>()
                .ForMember(dest => dest.Participants, opt => opt.MapFrom(e => e.Participants.Select(p => p.Person)));

            CreateMap<CalendarEvent, CalendarEventCalendarDto>();

            CreateMap<CalendarEvent, UpcomingEventDto>()
                .ForMember(dest => dest.Participants, opt => opt.MapFrom(e => e.Participants.Count))
                .ForMember(dest => dest.ParticipantIds, opt => opt.MapFrom(e => e.Participants.Select(p => p.PersonId)));
            CreateMap<ICollection<UpcomingEventDto>, ICollection<CalendarEvent>>();

            CreateMap<Person, PersonDto>();

            CreateMap<Award, AwardDto>()
                .ForMember(dest => dest.CalendarEventName, opt => opt.MapFrom(e => e.CalendarEvent.Name));

            CreateMap<Note, NoteDto>()
                .ForMember(dest => dest.FromFirstName, opt => opt.MapFrom(e => e.FromPerson.FirstName))
                .ForMember(dest => dest.FromLastName, opt => opt.MapFrom(e => e.FromPerson.LastName))
                .ForMember(dest => dest.ToLastName, opt => opt.MapFrom(e => e.ToPerson.FirstName))
                .ForMember(dest => dest.ToFirstName, opt => opt.MapFrom(e => e.ToPerson.LastName));
        }
    }
}
