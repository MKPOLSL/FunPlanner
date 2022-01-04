using FunPlannerShared.Data.Dtos;
using FunPlannerShared.Data.Entities;
using Refit;

namespace FunPlannerShared.Controllers
{
    public interface INoteController
    {
        [Get("/note")]
        Task<ICollection<NoteDto>> Get();

        [Post("/note")]
        Task AddNote(Guid personId, string note);
    }
}
