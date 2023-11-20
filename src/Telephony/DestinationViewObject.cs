using System;
using System.Collections.Generic;
using System.Text;
using System.Text.Json.Serialization;

namespace Sufficit.Telephony
{
    /// <summary>
    ///     Used for search used destinations at destinations view 
    /// </summary>
    public class DestinationViewObject : DestinationBase
    {
        public new Guid Id { get => base.Id ?? Guid.Empty; set => base.Id = value; }

        /// <summary>
        /// Context of this destination
        /// </summary>
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull | JsonIgnoreCondition.WhenWritingDefault)]
        public Guid ContextId { get; set; }

        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull | JsonIgnoreCondition.WhenWritingDefault)]
        public string? Filter { get; set; }
    }
}
