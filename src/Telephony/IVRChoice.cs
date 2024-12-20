using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Runtime.Serialization;
using System.Text.Json.Serialization;

namespace Sufficit.Telephony
{
    /// <summary>
    /// Interactive Voice Response user choice
    /// </summary>
    [DataContract]
    public class IVRChoice
    {
        /// <summary>
        /// IVR unique id
        /// </summary>
        [DataMember(Name = "ivrid", IsRequired = true, Order = 0)]
        [Column("ivrid")]
        public Guid IVRId { get; set; }

        /// <summary>
        /// Channel unique id
        /// </summary>
        [DataMember(Name = "uniqueid", IsRequired = true, Order = 1)]
        [Column("uniqueid"), StringLength(100)]
        public string UniqueId { get; set; } = default!;

        /// <summary>
        /// When happends
        /// </summary>
        public DateTime Timestamp { get; internal set; }

        /// <summary>
        /// From external destination phone or internal extension
        /// </summary>
        [DataMember(Name = "source", IsRequired = true, Order = 2)]
        [Column("source"), StringLength(100)]
        public string Source { get; set; } = default!;

        /// <summary>
        /// User input
        /// </summary>        
        [DataMember(Name = "digits", IsRequired = false, Order = 3)]
        [Column("digits"), StringLength(20)]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingDefault | JsonIgnoreCondition.WhenWritingNull)]
        public string? Digits { get; set; }

        /// <summary>
        /// Asterisk channel name
        /// </summary>
        [DataMember(Name = "channel", IsRequired = false, Order = 3)]
        [Column("channel"), StringLength(200)]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingDefault | JsonIgnoreCondition.WhenWritingNull)]
        public string? Channel { get; set; }

        /// <summary>
        /// Internal source, transfer extension, from app, etc
        /// </summary>
        [DataMember(Name = "internal", IsRequired = false, Order = 3)]
        [Column("internal"), StringLength(100)]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingDefault | JsonIgnoreCondition.WhenWritingNull)]
        public string? Internal { get; set; }
    }
}
