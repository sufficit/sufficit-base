using System;
using System.Text.Json.Serialization;

namespace Sufficit.Notification
{
    /// <summary>
    /// Lightweight event payload for websocket frontend updates.
    /// Must contain only non-sensitive data.
    /// </summary>
    public class WsEvent : NotificationEvent
    {
        public const string DefaultTitle = "WebSocket update";

        [JsonPropertyOrder(0)]
        [JsonPropertyName("id")]
        public override Guid Id { get; } = Guid.NewGuid();

        [JsonPropertyOrder(0)]
        [JsonPropertyName("title")]
        public override string Title => DefaultTitle;

        [JsonPropertyOrder(0)]
        [JsonPropertyName("method")]
        [JsonConverter(typeof(JsonStringEnumConverter))]
        public override SubscribeMethod Method => SubscribeMethod.ByContextId;

        [JsonPropertyOrder(1)]
        [JsonPropertyName("contextId")]
        public Guid ContextId { get; set; }

        [JsonPropertyOrder(2)]
        [JsonPropertyName("userId")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull | JsonIgnoreCondition.WhenWritingDefault)]
        public Guid? UserId { get; set; }

        [JsonPropertyOrder(3)]
        [JsonPropertyName("eventType")]
        public string? EventType { get; set; }

        [JsonPropertyOrder(4)]
        [JsonPropertyName("entityId")]
        public string? EntityId { get; set; }

        [JsonPropertyOrder(5)]
        [JsonPropertyName("entity")]
        public string? Entity { get; set; }

        [JsonPropertyOrder(6)]
        [JsonPropertyName("key")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull | JsonIgnoreCondition.WhenWritingDefault)]
        public string? Key { get; set; }

        [JsonPropertyOrder(7)]
        [JsonPropertyName("payload")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull | JsonIgnoreCondition.WhenWritingDefault)]
        public object? Payload { get; set; }

        public override Guid? GetContextId() => ContextId;

        public override string? GetKey() => Key ?? EntityId;
    }
}
