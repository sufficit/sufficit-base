using System;
using System.Collections.Generic;
using System.Text;

namespace Sufficit.Identity
{
    public class ReferenceToken
    {
        public string Key { get; set; } = default!;

        public Guid ContextId { get; set; } 

        public string ClientId { get; set; } = default!;

        public DateTimeOffset Creation { get; set; } 

        public DateTimeOffset? Expiration { get; set; }

        public string? Description { get; set; }
    }
}
