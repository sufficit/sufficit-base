using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sufficit.Telephony
{
    /// <summary>
    /// Extension Dial Alias
    /// </summary>
    public class EndPointAlias
    {
        public Guid EndPointId { get; set; }

        public Guid ContextId { get; set; }

        public string Alias { get; set; } = default!;

        public string? Title { get; set; }
    }
}
