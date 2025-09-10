using System;
using System.Text.Json.Serialization;

namespace Sufficit.Notification
{
    public class UnsubscribeRequest
    {
        [JsonPropertyName("messageid")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingDefault | JsonIgnoreCondition.WhenWritingNull)]
        public Guid? MessageId { get; set; }
    }
}
