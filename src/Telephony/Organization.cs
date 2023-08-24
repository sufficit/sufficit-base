using Sufficit.Telefonia;
using System;
using System.Collections.Generic;
using System.Text;

namespace Sufficit.Telephony
{
    /// <summary>
    ///     All client information and objects
    /// </summary>
    public class Organization
    {
        public Organization(Guid contextid) 
        { 
            ContextId = contextid;
        }

        public Guid ContextId { get; }

        public ContextMapping? Mapping { get; set; }

        public IEnumerable<DirectInwardDialing>? DIDs { get; set; }

        public IEnumerable<FilaEspera>? Queues { get; set; }

        public IEnumerable<EndPoint>? EndPoints { get; set; }
    }
}
