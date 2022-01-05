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

        [HttpGet()]
        public Task Get()
        {
            throw new NotImplementedException();
        }

        [HttpPost()]
        public Task AddAward(Guid personId, Guid eventId, AwardType awardType, string? message)
        {
            throw new NotImplementedException();
        }
    }
}
