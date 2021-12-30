namespace FunPlannerShared.Data.Entities
{
    public class Password
    {
        public Guid PersonId { get; set; }
        public string Passwd { get; set; }

        public virtual Person Person { get; set; }
    }
}
