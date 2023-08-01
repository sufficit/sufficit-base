using System;
using System.Collections.Generic;
using System.Text;
using System.Text.Json.Serialization;

namespace Sufficit.Telephony
{
    /// <summary>
    /// Request a notification for current balance for calls
    /// </summary>
    public sealed class BalanceNotifyRequest
    {
        /// <summary>
        /// Context to notify
        /// </summary>
        [JsonPropertyName("contextId")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingDefault)]
        public Guid ContextId { get; set; }

        [Obsolete("use ContextId instead")]
        [JsonIgnore(Condition = JsonIgnoreCondition.Always)]
        public Guid? IDContext { get => ContextId; set => ContextId = value ?? Guid.Empty; }

        /// <summary>
        /// Notify even if not has pending events
        /// </summary>
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingDefault)]
        public bool Force { get; set; } = false;
    }
}
