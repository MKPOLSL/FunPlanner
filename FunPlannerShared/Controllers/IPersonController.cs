using FunPlannerShared.Data.Dtos;
using FunPlannerShared.Data.Entities;
using Refit;

namespace FunPlannerShared.Controllers
{
    public interface IPersonController
    {
        [Get("/person")]
        Task<ICollection<PersonDto>> Get();

        [Get("/person/{firstName}-{lastName}")]
        Task<Person> GetByName(string firstName, string lastName);

        [Post("/person")]
        Task Post(Person person);

        [Get("/person/Get-by-email/{email}")]
        Task<PersonLoginDto?> GetByEmail(string email);

        [Post("/person/point")]
        Task AddPoint(Guid personId);
    }
}
