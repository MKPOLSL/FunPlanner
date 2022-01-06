using FunPlannerShared.Data.Dtos;
using FunPlannerShared.Data.Enums;
using Refit;

namespace FunPlannerShared.Controllers
{
    public interface IAwardController
    {
        [Get("/award/{id}")]
        Task<AwardDto> Get(Guid id);
        [Get("/award/get-by-person-id/{id}")]
        Task<ICollection<AwardDto>> GetByPersonId(Guid id);
        [Get("/award")]
        Task<ICollection<AwardDto>> GetAll();
        [Post("/award")]
        Task AddAward(Guid personId, Guid eventId, AwardType awardType, string? message);
    }
}
