using System;
using System.Collections.Generic;
using System.Text;

namespace Sufficit.Telephony.Exceptions
{
    public class ContextNotFoundException : Exception
    {
        public ContextNotFoundException(Guid contextId) { ContextId = contextId; }

        /// <summary>
        /// Client context unique id
        /// </summary>
        public Guid ContextId { get; }

        public override string Message { get { return $"telephony client context not found: { ContextId } !"; } }
    }
}
