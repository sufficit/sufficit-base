using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;
using System.Text.Json.Serialization;

namespace Sufficit.Telephony.WebRTC
{
    /// <summary>
    /// Real-Time Communication Session, identification and authorization
    /// </summary>
    public class WebRTCSession
    {
        [Key]
        [JsonPropertyName("userid")]
        [Column("userid", TypeName = "binary(16)")]
        public Guid UserID { get; set; }

        [JsonPropertyName("key")]
        [Column("key", TypeName = "binary(16)")]
        public Guid Key { get; set; }

        [JsonPropertyName("expiration")]
        [Column("expiration")]
        public DateTime Expiration { get; set; }

        [JsonPropertyName("creation")]
        [Column("creation")]
        [DatabaseGenerated(DatabaseGeneratedOption.Computed)]
        public DateTime Creation { get; set; }

        [JsonPropertyName("update")]
        [Column("update")]
        [DatabaseGenerated(DatabaseGeneratedOption.Computed)]
        public DateTime Update { get; set; }
    }
}
