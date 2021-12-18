using FunPlannerApi.Data;
using FunPlannerShared.Controllers;
using FunPlannerShared.Data.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace FunPlannerApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class PersonController : ControllerBase, IPersonController
    {
        private DbContext Context { get; set; }

        public PersonController(Context context)
        {
            Context = context;
        }

        [HttpGet(Name = "GetPersons")]
        public async Task<IEnumerable<Person>> Get()
        {
            return await Context.Set<Person>().ToListAsync();
        }

        [HttpPost(Name = "PostPerson")]
        public async Task Post(Person person)
        {
            Context.Add(person);
            await Context.SaveChangesAsync();
        }

        [HttpGet("{firstName}-{lastName}", Name = "GetPersonByName")]
        public async Task<Person> GetByName(string firstName, string lastName)
        {
            return await Context.Set<Person>().Where(p => firstName == firstName && lastName == lastName).FirstOrDefaultAsync();
        }
    }
}
