using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace Sufficit.Telephony.Audio
{
    /// <summary>
    ///     Fixed position for pabx audio file playback, see Url ...
    /// </summary>
    public class AudioPlaceHolder : IIncrementalTracking
    {
        [DataMember(Name = "id", IsRequired = true, Order = 0)]
        [Column("id"), JsonPropertyName("id")]
        public Guid Id { get; set; }

        [DataMember(Name = "cliente", IsRequired = true, Order = 0)]
        [Column("cliente"), JsonPropertyName("contextId")]
        public Guid ContextId { get; set; }

        [DataMember(Name = "titulo", IsRequired = true, Order = 0)]
        [Column("titulo"), StringLength(50), JsonPropertyName("title")]
        public string Title { get; set; } = default!;

        [DataMember(Name = "url", IsRequired = true, Order = 0)]
        [Column("url"), JsonPropertyName("url")]
        public Guid Url { get; set; }

        /// <summary>
        /// Logical last-change watermark used by incremental runtime refresh.
        /// </summary>
        [DataMember(Name = "timestamp", IsRequired = false, Order = 1)]
        [JsonPropertyName("timestamp")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingDefault)]
        public DateTime Timestamp { get; set; }

        /// <summary>
        /// Logical soft-delete marker. Null means the IVRMenu is active.
        /// </summary>
        [DataMember(Name = "deleted", IsRequired = false, Order = 2)]
        [JsonPropertyName("deleted")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull | JsonIgnoreCondition.WhenWritingDefault)]
        public DateTime? Deleted { get; set; }
    }
}
