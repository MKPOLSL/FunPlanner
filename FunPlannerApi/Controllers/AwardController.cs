using AutoMapper;
using FunPlannerApi.Data;
using FunPlannerShared.Controllers;
using FunPlannerShared.Data.Dtos;
using FunPlannerShared.Data.Entities;
using FunPlannerShared.Data.Enums;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace FunPlannerApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class AwardController : ControllerBase, IAwardController
    {
        private DbContext Context { get; set; }
        private IMapper Mapper { get; set; }

        public AwardController(Context context, IMapper mapper)
        {
            Context = context;
            Mapper = mapper;
        }

        [HttpGet("award/{id}")]
        public Task<AwardDto> Get(Guid id)
        {
            throw new NotImplementedException();
        }

        [HttpGet("/award")]
        public Task<ICollection<AwardDto>> GetAll()
        {
            throw new NotImplementedException();
        }

        [HttpPost("/award")]
        public Task AddAward(Guid personId, Guid eventId, AwardType awardType, string? message)
        {
            throw new NotImplementedException();
        }

        [HttpGet("/award/get-by-person-id/{id}")]
        public async Task<ICollection<AwardDto>> GetByPersonId(Guid id)
        {
            var award = await Context.Set<Award>()
                .Include(a => a.CalendarEvent)
                .Where(a => a.PersonId == id)
                .FirstOrDefaultAsync();

            return Mapper.Map<ICollection<AwardDto>>(award);
        }
    }
}
