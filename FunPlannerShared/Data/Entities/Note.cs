namespace FunPlannerShared.Data.Entities
{
    public class Note : IdentityEntity
    {
        public Guid ToPersonId { get; set; }
        public Person ToPerson { get; set; }
        public Guid FromPersonId { get; set; }
        public Person FromPerson { get; set; }
        public string Content { get; set; }
    }
}
