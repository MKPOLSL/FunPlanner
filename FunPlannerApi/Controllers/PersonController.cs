using FunPlannerApi.Data;
using FunPlannerShared.Data.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace FunPlannerApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class PersonController : ControllerBase
    {
        private DbSet<Person> Context { get; set; }

        public PersonController(Context context)
        {
            Context = context.Set<Person>();
        }

        [HttpGet(Name = "GetPersons")]
        public async Task<IEnumerable<Person>> Get()
        {
            return await Context.ToListAsync();
        }
    }
}
