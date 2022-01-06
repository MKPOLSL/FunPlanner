using FunPlannerShared.Data.Dtos;
using Refit;

namespace FunPlannerShared.Controllers
{
    public interface IAuthorizationController
    {
        [Get("/authorization/validate")]
        Task<ValidationResult> ValidateUser(string email, string password);
    }
}
