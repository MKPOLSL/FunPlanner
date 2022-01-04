using FunPlannerShared.Data.Dtos;
using FunPlannerShared.Data.Entities;
using FunPlannerShared.Data.Enums;
using Refit;

namespace FunPlannerShared.Controllers
{
    public interface IAwardController
    {
        [Get("/award")]
        Task Get();
        [Post("/award")]
        Task AddAward(Guid personId, Guid eventId, AwardType awardType, string? message);
    }
}
