using System;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using Sufficit.Exchange;
using Sufficit.Notification;

namespace Sufficit.Support
{
    /// <summary>
    /// Internal event raised once per accepted change (never on replays). Carries no message text: live consumers
    /// reload the thread through the API.
    /// </summary>
    public sealed class SupportThreadChangedEvent
    {
        public Guid ContextId { get; set; }
        public Guid ThreadId { get; set; }
        public Guid MessageId { get; set; }
        public string Kind { get; set; } = string.Empty;
        /// <summary>One of <see cref="SupportChanges"/>.</summary>
        public string Change { get; set; } = string.Empty;
        /// <summary>Side that made the change.</summary>
        public string Side { get; set; } = string.Empty;
        public string? WaitingFor { get; set; }
        public string State { get; set; } = string.Empty;
        public string? Source { get; set; }
        public long Revision { get; set; }
        public DateTime AtUtc { get; set; }

        public static SupportThreadChangedEvent From(SupportWriteResult result, string change) => new SupportThreadChangedEvent
        {
            ContextId = result.Thread.ContextId, ThreadId = result.Thread.Id, MessageId = result.Message.Id, Kind = result.Thread.Kind,
            Change = change, Side = result.Message.Side, WaitingFor = result.Thread.WaitingFor, State = result.Thread.State,
            Source = result.Thread.Source, Revision = result.Thread.Revision, AtUtc = result.Message.CreatedAtUtc,
        };
    }

    /// <summary>Base of the dispatch-system events: a change in a support thread, with subject and message text.</summary>
    public abstract class SupportNEvent : NotificationEvent
    {
        protected SupportNEvent() { Change = new SupportThreadChangedEvent(); }
        protected SupportNEvent(SupportThreadChangedEvent change, string subject, string body)
        { Change = change; Subject = subject; Body = body; }

        [JsonPropertyName("change")] public SupportThreadChangedEvent Change { get; set; }
        [JsonPropertyName("subject")] public string Subject { get; set; } = string.Empty;
        [JsonPropertyName("body")] public string Body { get; set; } = string.Empty;

        public override Guid? GetContextId() => Change.ContextId;
        public override Guid? GetReferenceId() => Change.ThreadId;

        public override ValueTask<string> GetBody(string? extra = null, TChannel channel = default)
        {
            // Webhooks receive the JSON envelope (change + subject + body) so an agent can act on it.
            if (channel == TChannel.WEBHOOK) return base.GetBody(extra, channel);
            var text = $"[{Change.Kind}] {Subject}\n{Body}\n\nThread {Change.ThreadId} ({Change.Change}, {Change.Side})";
            return new ValueTask<string>(text);
        }
    }

    /// <summary>
    /// Sufficit inbox: every customer change, for Sufficit's own subscribers (key <see cref="Key"/>: e-mail,
    /// WhatsApp or a webhook that wakes an internal agent).
    /// </summary>
    [NotificationEventCollection]
    public sealed class SupportInboxNEvent : SupportNEvent
    {
        public const string IDEVENT = "0f6f4a8e-3c1b-4f53-9a51-2d1b7c5e9a10";
        public const string TITLE = "Suporte: novidade de cliente";
        /// <summary>Global subscription key of Sufficit's support inbox.</summary>
        public const string Key = "sufficit-support";
        public SupportInboxNEvent() { }
        public SupportInboxNEvent(SupportThreadChangedEvent change, string subject, string body) : base(change, subject, body) { }
        public override Guid Id { get; } = Guid.Parse(IDEVENT);
        public override string Title => TITLE;
        public override SubscribeMethod Method => SubscribeMethod.ByKey;
        public override string? GetKey() => Key;
    }

    /// <summary>Customer side: every Sufficit change, for the contacts the customer context subscribed.</summary>
    [NotificationEventCollection]
    public sealed class SupportReplyNEvent : SupportNEvent
    {
        public const string IDEVENT = "6a2d3c71-8e4f-4b0a-b6c2-5f8e1d9a7b34";
        public const string TITLE = "Suporte: resposta da Sufficit";
        public SupportReplyNEvent() { }
        public SupportReplyNEvent(SupportThreadChangedEvent change, string subject, string body) : base(change, subject, body) { }
        public override Guid Id { get; } = Guid.Parse(IDEVENT);
        public override string Title => TITLE;
        public override SubscribeMethod Method => SubscribeMethod.ByContextId;
    }
}
