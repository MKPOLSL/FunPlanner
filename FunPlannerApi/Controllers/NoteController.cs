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

        [HttpPost("/note")]
        public async Task AddNote(Guid FromPersonId, Guid ToPersonId, string note)
        {
            var newNote = new Note
            {
                FromPersonId = FromPersonId,
                ToPersonId = ToPersonId,
                Content = note
            };
            Context.Add(newNote);
            await Context.SaveChangesAsync();
        }

        [HttpGet("/note")]
        public async Task<ICollection<NoteDto>> GetAll()
        {
            var notes = await Context.Set<Note>()
                .Include(n => n.ToPerson)
                .Include(n => n.FromPerson)
                .ToListAsync();
            return Mapper.Map<ICollection<NoteDto>>(notes);
        }

        [HttpGet("/note/get-by-person-id/{id}")]
        public async Task<ICollection<NoteDto>> GetAllByPersonId(Guid id)
        {
            var notes = await Context.Set<Note>()
                .Include(n => n.FromPerson)
                .Include(n => n.ToPerson)
                .Where(n => n.ToPersonId == id)
                .ToListAsync();
            return Mapper.Map<ICollection<NoteDto>>(notes);
        }

        [HttpDelete("/note/{id}")]
        public async Task Delete(Guid id)
        {
            var note = await Context.Set<Note>()
                .FirstOrDefaultAsync(ce => ce.Id == id);

            if (note == null)
                throw new HttpRequestException("Note not found.");

            Context.Remove(note);
            await Context.SaveChangesAsync();
        }
    }
}
