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
        public async Task<AwardDto> Get(Guid id)
        {
            var award = await Context.Set<Award>()
                 .Include(a => a.CalendarEvent)
                 .FirstOrDefaultAsync(a => a.Id == id);
            return Mapper.Map<AwardDto>(award);
        }

        [HttpGet("/award")]
        public async Task<ICollection<AwardDto>> GetAll()
        {
            var award = await Context.Set<Award>()
                .Include(a => a.CalendarEvent)
                .ToListAsync();

            return Mapper.Map<ICollection<AwardDto>>(award);
        }

        [HttpPost("/award")]
        public async Task AddAward(Guid personId, Guid eventId, AwardType awardType, string? message)
        {
            Award award = new()
            {
                PersonId = personId,
                CalendarEventId = eventId,
                AwardType = awardType
            };
            Context.Add(award);
            await Context.SaveChangesAsync();
        }

        [HttpGet("/award/get-by-person-id/{id}")]
        public async Task<ICollection<AwardDto>> GetByPersonId(Guid id)
        {
            var award = await Context.Set<Award>()
                .Include(a => a.CalendarEvent)
                .Where(a => a.PersonId == id)
                .ToListAsync();

            return Mapper.Map<ICollection<AwardDto>>(award);
        }

        [HttpDelete("/award/{id}")]
        public async Task Delete(Guid id)
        {
            var award = await Context.Set<Award>()
                .FirstOrDefaultAsync(ce => ce.Id == id);

            if (award == null)
                throw new HttpRequestException("Award not found.");

            Context.Remove(award);
            await Context.SaveChangesAsync();
        }
    }
}
