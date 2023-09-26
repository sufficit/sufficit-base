using System;
using System.Collections.Generic;
using System.Text;

namespace Sufficit.Sales
{
    public class Group
    {
        public Guid Id { get; set; }

        public ICollection<Guid> MembersIds { get; set; } 
            = new HashSet<Guid>();   
    }
}
