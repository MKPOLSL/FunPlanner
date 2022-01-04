using AutoMapper;
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
        private IMapper Mapper { get; set; }

        public PersonController(Context context, IMapper mapper)
        {
            Context = context;
            Mapper = mapper;
        }

        [HttpGet(Name = "GetPersons")]
        public async Task<ICollection<PersonDto>> Get()
        {
            var persons = await Context.Set<Person>().ToListAsync();
            return Mapper.Map<List<PersonDto>>(persons);
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

        [HttpGet("/person/Get-by-email/{email}", Name = "GetPersonByEmail")]
        public async Task<PersonLoginDto?> GetByEmail(string email)
        {
            var person = await Context.Set<Person>()
                .Where(p => p.Email == email)
                .FirstOrDefaultAsync();

            if (person == null)
                return null;

            return new PersonLoginDto
            {
                Id = person.Id,
                FirstName = person.FirstName,
                LastName = person.LastName,
                Email = person.Email,
            };
        }

        [HttpGet("/person/validate", Name = "ValidateUser")]
        public async Task<ValidationResult> ValidateUser([FromQuery] string email, [FromQuery] string password)
        {
            var person = await Context.Set<Person>()
                .Include(p => p.Password)
                .Where(p => p.Email == email)
                .FirstOrDefaultAsync();

            var result = password == person?.Password.Passwd ?
                new ValidationResult { IsValidated = true } :
                new ValidationResult { IsValidated = false };

            return result;
        }

        [HttpPost("/person/note")]
        public async Task AddNote(Guid personId, string note)
        {
            var newNote = new Note
            {
                PersonId = personId,
                Content = note
            };
            Context.Add(newNote);
            await Context.SaveChangesAsync();
        }

        [HttpPost("/person/point")]
        public async Task AddPoint(Guid personId)
        {
            var person = await Context.Set<Person>().Where(p => p.Id == personId).FirstOrDefaultAsync();
            if(person == null)
                throw new HttpRequestException("Person not found."); 
            person.Points++;
            Context.Update(person);
            await Context.SaveChangesAsync();
        }
    }
}
