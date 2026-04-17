using Sufficit.Telephony.Asterisk;
using System;
using System.ComponentModel.DataAnnotations.Schema;
using System.Runtime.Serialization;
using System.Text.Json.Serialization;

namespace Sufficit.Telephony
{
    /// <summary>
    /// IVR | Menu<br />
    /// Enchanced Interactive Voice Response
    /// </summary>
    [DataContract]
    public class IVROption : AsteriskMenuOption, IIncrementalTracking
    {
        /// <summary>
        /// Unique ID
        /// </summary>
        [DataMember(Name = "ivrid", IsRequired = true, Order = 0)]
        [Column("ivrid")]
        public Guid IVRId { get; set; }

        /// <summary>
        /// Logical last-change watermark used by incremental runtime refresh.
        /// </summary>
        [JsonPropertyName("timestamp")]
        [DataMember(Name = "timestamp", IsRequired = false, Order = 4)]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingDefault)]
        public DateTime Timestamp { get; set; }

        /// <summary>
        /// Logical soft-delete marker. Null means the option is active.
        /// </summary>
        [JsonPropertyName("deleted")]
        [DataMember(Name = "deleted", IsRequired = false, Order = 5)]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull | JsonIgnoreCondition.WhenWritingDefault)]
        public DateTime? Deleted { get; set; }
    }
}
