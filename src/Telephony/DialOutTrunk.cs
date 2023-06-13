using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace Sufficit.Telephony
{
    /// <summary>
    /// Tronco usado para discagem externa
    /// </summary>
    public class DialOutTrunk
    {
        public Guid ContextId { get; set; }

        public string Title { get; set; } = default!;

        public int Channels { get; set; }

        /// <summary>
        /// Data/Hora de expiração do serviço desse tronco específico
        /// </summary>
        [DateTimeKind(DateTimeKind.Utc)]
        public DateTime Expire { get; set; }

        [JsonPropertyName("timestamp")]
        [Column("update")]
        [DatabaseGenerated(DatabaseGeneratedOption.Computed)]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingDefault)]
        public DateTimeOffset Timestamp { get; }
    }
}
