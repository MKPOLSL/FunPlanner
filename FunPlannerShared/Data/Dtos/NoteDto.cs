using FunPlannerShared.Data.Entities;

namespace FunPlannerShared.Data.Dtos
{
    public class NoteDto : IdentityEntity
    {
        public string Content { get; set; }
        public Guid PersonId { get; set; }
    }
}
