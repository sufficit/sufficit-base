using System;
using System.Collections.Generic;
using System.Text;
using System.Text.Json.Serialization;

namespace Sufficit.Exchange
{
    public interface IMessageExtendedInfo
    {
        /// <summary>
        ///     Optional Guid to indicate a message model or event type, facilitate for track systems
        /// </summary>
        Guid? ModelId { get; }

        /// <summary>
        ///     Object reference id, used to specify a target context item
        /// </summary>
        Guid? ReferenceId { get; }

        /// <summary>
        ///     Indicate a client|customer context for filtering purposes 
        /// </summary>
        Guid? ContextId { get; }
    }
}
