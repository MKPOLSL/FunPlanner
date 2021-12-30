using FunPlannerShared.Data.Dtos;
using FunPlannerShared.Data.Entities;
using Refit;

namespace FunPlannerShared.Controllers
{
    public interface IPersonController
    {
        [Get("/Person")]
        Task<ICollection<Person>> Get();

        [Get("/Person/{firstName}-{lastName}")]
        Task<Person> GetByName(string firstName, string lastName);

        [Post("/Person")]
        Task Post(Person person);

        [Get("/Person/{email}")]
        Task<PersonLoginDto?> GetByEmail(string email);
    }
}
