using System;

namespace Sufficit.Telephony.VoiceAgent
{
    // Tool requests of the voice agent API. The agent catalog publishes these type names and fields, so renaming
    // one changes what the model reads. Required strings default to null, not empty: the API's implicit [Required]
    // must reject a field that is absent.

    public sealed class CallRequest
    {
        public CallRequest() { }

        public CallRequest(string method, string path, string? body)
        {
            Method = method;
            Path = path;
            Body = body;
        }

        public string Method { get; set; } = null!;
        public string Path { get; set; } = null!;
        public string? Body { get; set; }
    }

    public sealed class MessageRequest
    {
        public MessageRequest() { }

        public MessageRequest(string? number, string text, string? destinationId = null)
        {
            Number = number;
            Text = text;
            DestinationId = destinationId;
        }

        public string? Number { get; set; }
        public string Text { get; set; } = null!;
        public string? DestinationId { get; set; }
    }

    public sealed class RecordingMessageRequest
    {
        public RecordingMessageRequest() { }

        public RecordingMessageRequest(string callId, string destinationId, Guid? contextId = null)
        {
            CallId = callId;
            DestinationId = destinationId;
            ContextId = contextId;
        }

        public string CallId { get; set; } = null!;
        public string DestinationId { get; set; } = null!;
        public Guid? ContextId { get; set; }
    }

    public sealed class RecordingRequest
    {
        public RecordingRequest() { }

        public RecordingRequest(Guid? contextId, string callId)
        {
            ContextId = contextId;
            CallId = callId;
        }

        public Guid? ContextId { get; set; }
        public string CallId { get; set; } = null!;
    }

    public sealed class PrepareQueueRequest
    {
        public PrepareQueueRequest() { }

        public PrepareQueueRequest(Guid contextId, Guid didId, Guid queueId, bool ringingOnly, string reason)
        {
            ContextId = contextId;
            DidId = didId;
            QueueId = queueId;
            RingingOnly = ringingOnly;
            Reason = reason;
        }

        public Guid ContextId { get; set; }
        public Guid DidId { get; set; }
        public Guid QueueId { get; set; }
        public bool RingingOnly { get; set; }
        public string Reason { get; set; } = null!;
    }

    public sealed class ApplyQueueRequest
    {
        public ApplyQueueRequest() { }

        public ApplyQueueRequest(string operationToken) => OperationToken = operationToken;

        public string OperationToken { get; set; } = null!;
    }

    public sealed class RemoveRequest
    {
        public RemoveRequest() { }

        public RemoveRequest(Guid contextId, Guid endPointId, string expectedRevision, string reason)
        {
            ContextId = contextId;
            EndPointId = endPointId;
            ExpectedRevision = expectedRevision;
            Reason = reason;
        }

        public Guid ContextId { get; set; }
        public Guid EndPointId { get; set; }
        public string ExpectedRevision { get; set; } = null!;
        public string Reason { get; set; } = null!;
    }
}
