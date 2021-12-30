using FunPlannerApi.Data;
using FunPlannerShared.Controllers;
using FunPlannerShared.Data.Dtos;
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
        public async Task<ICollection<Person>> Get()
        {
            var persons = await Context.Set<Person>().ToListAsync();
            return persons;
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

        [HttpGet("{email}", Name = "GetPersonByEmail")]
        public async Task<PersonLoginDto?> GetByEmail(string email)
        {
            var person =  await Context.Set<Person>()
                .Include(p => p.Password)
                .Where(p => p.Email == email)
                .FirstOrDefaultAsync();

            if(person == null)
                return null;

            return new PersonLoginDto
            {
                FirstName = person.FirstName,
                LastName = person.LastName,
                Email = person.Email,
                Password = person.Password.Passwd
            };
        }
    }
}
