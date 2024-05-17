using Sufficit.Exchange;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;

namespace Sufficit.Notification
{
    public class NotifyReport : List<NotifyReportItem>
    {
        [JsonPropertyName("count")]
        [JsonIgnore(Condition = JsonIgnoreCondition.Never)]
        public int Total => this.Count;

        [JsonPropertyName("success")]
        [JsonIgnore(Condition = JsonIgnoreCondition.Never)]
        public bool Success => this.All(s => s.Success);
    }

    public class NotifyReportItem
    {
        public NotifyReportItem(Message message) => this.Message = message;
        public Message Message { get; set; }
        public bool Success { get; set; }
    }
}
