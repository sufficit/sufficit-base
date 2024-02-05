using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Runtime.Serialization;
using System.Text;
using System.Text.Json.Serialization;

namespace Sufficit.Telephony
{
    /// <summary>
    ///     Generic endpoint and context property
    /// </summary>
    public class EndPointProperty
    {
        /// <summary>
        ///     Client Id
        /// </summary>
        [DataMember(Name = "contextid", IsRequired = true, Order = 0)]
        [Column("contextid")]
        [JsonPropertyName("contextid")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingDefault)]
        public Guid ContextId { get; set; }

        /// <summary>
        ///     EndPoint Id
        /// </summary>
        [DataMember(Name = "endpointid", IsRequired = true, Order = 1)]
        [Column("endpointid")]
        [JsonPropertyName("endpointid")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingDefault)]
        public Guid EndPointId { get; set; }

        [JsonPropertyName("key")]
        public virtual string Key { get; set; } = default!;

        [JsonPropertyName("value")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull | JsonIgnoreCondition.WhenWritingDefault)]
        public virtual string? Value { get; set; }

        /// <summary>
        ///     Last update time
        /// </summary>
        [DataMember(Name = "timestamp", IsRequired = true, Order = 4)]
        [Column("timestamp"), DatabaseGenerated(DatabaseGeneratedOption.Computed)]
        [JsonIgnore]
        public DateTime Timestamp { get; set; }
    }
}
