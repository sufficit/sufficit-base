using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Net;
using System.Text;
using System.Text.Json.Serialization;

namespace Sufficit.Telephony
{
    public class Device
    {
        [JsonPropertyName("macaddress")]
        public string MACAddress { get; set; } = default!;

        [JsonPropertyName("contextid")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull | JsonIgnoreCondition.WhenWritingDefault)]
        public Guid? ContextId { get; set; }

        [JsonPropertyName("extensionid")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull | JsonIgnoreCondition.WhenWritingDefault)]
        public Guid? ExtensionId { get; set; }

        [JsonPropertyName("ipaddress")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull | JsonIgnoreCondition.WhenWritingDefault)]
        public string? IPAddress { get; set; }

        [JsonPropertyName("match")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull | JsonIgnoreCondition.WhenWritingDefault)]
        public string? Match { get; set; }

        [JsonPropertyName("timestamp")]
        [Column("update")]
        [DatabaseGenerated(DatabaseGeneratedOption.Computed)]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingDefault)]
        public DateTimeOffset Timestamp { get; set; }
    }
}
