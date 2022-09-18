using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sufficit.Telephony
{
    /// <summary>
    /// External dial direct to an internal extension
    /// </summary>
    public class DirectExtensionDialing : IDestination
    {
        public Guid? Id { get; set; }

        public string TypeName => typeof(DirectExtensionDialing).Name;

        public Guid? ContextId { get; set; }

        public string Asterisk { get; set; } = default!;

        public string? Title { get; set; }

        public string? Description { get; set; }
    }
}
