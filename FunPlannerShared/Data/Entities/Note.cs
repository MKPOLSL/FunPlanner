using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FunPlannerShared.Data.Entities
{
    public class Note : IdentityEntity
    {
        public Guid PersonId { get; set; }
        public string Content { get; set; }
        public Person Person { get; set; }
    }
}
