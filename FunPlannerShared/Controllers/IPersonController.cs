using FunPlannerShared.Data.Entities;
using Refit;

namespace FunPlannerShared.Controllers
{
    public interface IPersonController
    {
        [Get("/Person")]
        Task<IEnumerable<Person>> Get();

        [Post("/Person")]
        Task Post(Person person);
    }
}
