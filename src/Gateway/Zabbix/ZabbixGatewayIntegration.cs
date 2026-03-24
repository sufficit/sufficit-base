using System;
using System.Text.Json.Serialization;

namespace Sufficit.Gateway.Zabbix
{
    public class ZabbixGatewayIntegration
    {
        [JsonPropertyName("id")]
        public Guid Id { get; set; }

        [JsonPropertyName("contextid")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingDefault)]
        public Guid ContextId { get; set; }

        [JsonPropertyName("title")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull | JsonIgnoreCondition.WhenWritingDefault)]
        public string? Title { get; set; }

        [JsonPropertyName("enabled")]
        public bool Enabled { get; set; } = true;

        [JsonPropertyName("flap_mode")]
        public ZabbixFlapMode FlapMode { get; set; } = ZabbixFlapMode.SuppressWindow;

        [JsonPropertyName("flap_window_seconds")]
        public int FlapWindowSeconds { get; set; } = 120;

        [JsonPropertyName("identifier")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull | JsonIgnoreCondition.WhenWritingDefault)]
        public string? Identifier { get; set; }

        [JsonPropertyName("digit")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull | JsonIgnoreCondition.WhenWritingDefault)]
        public uint? Digit { get; set; }

        [JsonPropertyName("timestamp")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingDefault)]
        public DateTime Timestamp { get; set; }
    }
}
