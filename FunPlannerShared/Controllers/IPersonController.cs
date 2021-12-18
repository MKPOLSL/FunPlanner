using FunPlannerShared.Data.Entities;
using Refit;

namespace FunPlannerShared.Controllers
{
    public interface IPersonController
    {
        [Get("/Person")]
        Task<IEnumerable<Person>> Get();

        [Get("/Person/{firstName}-{lastName}")]
        Task<Person> GetByName(string firstName, string lastName);

        [Post("/Person")]
        Task Post(Person person);
    }
}
