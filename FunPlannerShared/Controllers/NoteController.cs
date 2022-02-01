using FunPlannerShared.Data.Dtos;
using Refit;

namespace FunPlannerShared.Controllers
{
    public interface INoteController
    {
        [Get("/note")]
        Task<ICollection<NoteDto>> GetAll();

        [Get("/note/get-by-person-id/{id}")]
        Task<ICollection<NoteDto>> GetAllByPersonId(Guid id);

        [Post("/note")]
        Task AddNote(Guid FromPersonId, Guid ToPersonId, string note);

        [Delete("/note/{id}")]
        Task Delete(Guid id);
    }
}
