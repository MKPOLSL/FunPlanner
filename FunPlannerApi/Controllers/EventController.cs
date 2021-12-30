using AutoMapper;
using FunPlannerApi.Data;
using FunPlannerShared.Controllers;
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
        public async Task Post([FromBody] CalendarEventDto calendarEvent)
        {
            var newEvent = Mapper.Map<CalendarEvent>(calendarEvent);
            Context.Add(newEvent);
            await Context.SaveChangesAsync();
        }

        [HttpGet(Name = "GetEvents")]
        public async Task<ICollection<CalendarEvent>> Get()
        {
            return await Context.Set<CalendarEvent>().ToListAsync();
        }

        [HttpGet("/Upcoming", Name = "Upcoming")]
        public async Task<ICollection<CalendarEvent>> GetUpcoming()
        {
            var events =  await Context.Set<CalendarEvent>().Where(e => e.Start > DateTime.Now).OrderBy(e => e.Start).ToListAsync();
            if(events.Any())
                return events;
            return new List<CalendarEvent>();
        }
    }
}
