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

        public EventController(Context context)
        {
            Context = context;
        }

        [HttpPost(Name = "PostEvent")]
        public async Task Post([FromBody] CalendarEvent calendarEvent)
        {
            Context.Add(calendarEvent);
            await Context.SaveChangesAsync();
        }
    }
}
