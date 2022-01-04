using FunPlannerShared.Data.Entities;
using FunPlannerShared.Data.Enums;

namespace FunPlannerShared.Data.Dtos
{
    public class PersonDto : IdentityEntity
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public int Points { get; set; }
        public Role Role { get; set; }
    }
}
