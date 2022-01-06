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
    public class AuthorizationController : ControllerBase, IAuthorizationController
    {
        private DbContext Context { get; set; }

        public AuthorizationController(Context context, IMapper mapper)
        {
            Context = context;
        }

        [HttpGet("/authorization/validate", Name = "ValidateUser")]
        public async Task<ValidationResult> ValidateUser([FromQuery] string email, [FromQuery] string password)
        {
            var person = await Context.Set<Person>()
                .Include(p => p.Password)
                .Where(p => p.Email == email)
                .FirstOrDefaultAsync();

            var result = password == person?.Password.Passwd ?
                new ValidationResult { IsValidated = true } :
                new ValidationResult { IsValidated = false };

            return result;
        }
    }
}
