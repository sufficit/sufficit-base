using System;

namespace Sufficit.Telephony.VoiceSupport
{
    // Connector and agent requests of telephony/voice-support. Required strings default to null, not empty:
    // the API's implicit [Required] must reject a field that is absent.

    public sealed class BindRequest
    {
        public BindRequest() { }

        public BindRequest(string conversationId, Guid agentId, Guid originContextId, Guid endPointId)
        {
            ConversationId = conversationId;
            AgentId = agentId;
            OriginContextId = originContextId;
            EndPointId = endPointId;
        }

        public string ConversationId { get; set; } = null!;
        public Guid AgentId { get; set; }
        public Guid OriginContextId { get; set; }
        public Guid EndPointId { get; set; }
    }

    public sealed class BindAliasRequest
    {
        public BindAliasRequest() { }

        public BindAliasRequest(string conversationId, Guid agentId, Guid originContextId, string alias)
        {
            ConversationId = conversationId;
            AgentId = agentId;
            OriginContextId = originContextId;
            Alias = alias;
        }

        public string ConversationId { get; set; } = null!;
        public Guid AgentId { get; set; }
        public Guid OriginContextId { get; set; }
        public string Alias { get; set; } = null!;
    }

    public sealed class ResolveAliasRequest
    {
        public ResolveAliasRequest() { }

        public ResolveAliasRequest(Guid originContextId, string alias)
        {
            OriginContextId = originContextId;
            Alias = alias;
        }

        public Guid OriginContextId { get; set; }
        public string Alias { get; set; } = null!;
    }

    public sealed class HistoryRequest
    {
        public HistoryRequest() { }

        public HistoryRequest(Guid contextId, DateTimeOffset start, DateTimeOffset end, int limit = 5, bool ownExtension = true, bool recordedOnly = false)
        {
            ContextId = contextId;
            Start = start;
            End = end;
            Limit = limit;
            OwnExtension = ownExtension;
            RecordedOnly = recordedOnly;
        }

        public Guid ContextId { get; set; }
        public DateTimeOffset Start { get; set; }
        public DateTimeOffset End { get; set; }
        public int Limit { get; set; } = 5;
        public bool OwnExtension { get; set; } = true;
        public bool RecordedOnly { get; set; }
    }

    public sealed class RecordingRequest
    {
        public RecordingRequest() { }

        public RecordingRequest(Guid contextId, string callId)
        {
            ContextId = contextId;
            CallId = callId;
        }

        public Guid ContextId { get; set; }
        public string CallId { get; set; } = null!;
    }

    public sealed class WhatsAppRequest
    {
        public WhatsAppRequest() { }

        public WhatsAppRequest(Guid requestId, string number, string text)
        {
            RequestId = requestId;
            Number = number;
            Text = text;
        }

        public Guid RequestId { get; set; }
        public string Number { get; set; } = null!;
        public string Text { get; set; } = null!;
    }
}
