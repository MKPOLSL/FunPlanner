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
    public class NoteController : ControllerBase, INoteController
    {
        private DbContext Context { get; set; }
        private IMapper Mapper { get; set; }

        public NoteController(Context context, IMapper mapper)
        {
            Context = context;
            Mapper = mapper;
        }

        [HttpGet("/note")]
        public async Task<ICollection<NoteDto>> Get()
        {
            var notes = await Context.Set<Note>().ToListAsync();
            return Mapper.Map<ICollection<NoteDto>>(notes);
        }

        [HttpPost("/note")]
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
    }
}
