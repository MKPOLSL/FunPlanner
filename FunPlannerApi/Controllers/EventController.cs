using AutoMapper;
using FunPlannerApi.Data;
using FunPlannerShared.Controllers;
using FunPlannerShared.Data.Dtos;
using FunPlannerShared.Data.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FunPlannerApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class EventController : ControllerBase, IEventController
    {
        private DbContext Context { get; set; }
        private IMapper Mapper { get; set; }

        public EventController(Context context, IMapper mapper)
        {
            Context = context;
            this.Mapper = mapper;
        }

        [HttpPost(Name = "PostEvent")]
        public async Task Post([FromBody] CalendarEventCreateDto calendarEvent)
        {
            var newEvent = Mapper.Map<CalendarEvent>(calendarEvent);
            Context.Add(newEvent);
            await Context.SaveChangesAsync();
        }

        [HttpGet(Name = "GetEvents")]
        public async Task<ICollection<CalendarEvent>> Get()
        {
            return await Context.Set<CalendarEvent>().OrderByDescending(o => o.Start).ToListAsync();
        }

        [HttpGet("/event/upcoming", Name = "Upcoming")]
        public async Task<ICollection<UpcomingEventDto>> GetUpcoming()
        {
            ICollection<CalendarEvent> events =  
                await Context.Set<CalendarEvent>()
                .Where(e => e.Start > DateTime.Now)
                .OrderBy(e => e.Start)
                .Include(e => e.Participants)
                .ToListAsync();

            if (events.Any())
            {
                var upcomingEvents = new List<UpcomingEventDto>();
                upcomingEvents = Mapper.Map<List<UpcomingEventDto>>(events);
                return upcomingEvents;
            }
            return new List<UpcomingEventDto>();
        }

        [HttpPost("/event/sign-me", Name = "SignToEvent")]
        public async Task AssignPersonToEvent(Guid eventId, Guid personId)
        {
            var eventToAssign =
                await Context.Set<CalendarEvent>()
                .Where(e => e.Id == eventId)
                .Include(e => e.Participants)
                .OrderBy(e => e.Start).FirstOrDefaultAsync();
            if (eventToAssign == null)
                throw new HttpRequestException("Event not found.");

            if(eventToAssign.Participants.Select(p => p.PersonId).Contains(personId))
                    throw new HttpRequestException("Already assigned to event!");

            var eventParticipants = new EventParticipants
            {
                PersonId = personId,
                EventId = eventId
            };
            await Context.AddAsync(eventParticipants);
            await Context.SaveChangesAsync();
        }

        [HttpGet("/event/calendar", Name = "Calendar")]
        public async Task<ICollection<CalendarEventCalendarDto>> GetForCalendar()
        {
            var events = await Context.Set<CalendarEvent>().OrderBy(o => o.Start).ToListAsync();
            return Mapper.Map<List<CalendarEventCalendarDto>>(events);
        }

        [HttpDelete("/event/{id}")]
        public Task Delete(Guid id)
        {
            throw new NotImplementedException();
        }

        [HttpGet("/event/{id}/participants")]
        public async Task<CalendarEventDto> GetWithParticipants(Guid id)
        {
            var calendarEvent = await Context.Set<CalendarEvent>()
                .Where(e => e.Id == id)
                .Include(e => e.Participants)
                    .ThenInclude(e => e.Person)
                .FirstOrDefaultAsync();
            return Mapper.Map<CalendarEventDto>(calendarEvent);
        }
    }
}
