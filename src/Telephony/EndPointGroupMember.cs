using System;
using System.Collections.Generic;
using System.Text;

namespace Sufficit.Telephony
{
    public class EndPointGroupMember
    {
        public Guid EndPointId { get; set; }

        public string Key { get; set; } = default!;

        public Guid GroupId { get; set; }
    }    
}
