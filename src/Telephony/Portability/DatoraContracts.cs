using System;

namespace Sufficit.Telephony.Portability
{
    // Required strings default to null, not empty: the API's implicit [Required] must reject a field that is absent.

    /// <summary>SIP registration requested from the restricted Datora activation endpoint.</summary>
    public sealed class DatoraActivationRequest
    {
        public DatoraActivationRequest() { }

        public DatoraActivationRequest(Guid contextId, string did, string password, Guid effectId)
        {
            ContextId = contextId;
            Did = did;
            Password = password;
            EffectId = effectId;
        }

        public Guid ContextId { get; set; }
        public string Did { get; set; } = null!;
        public string Password { get; set; } = null!;
        public Guid EffectId { get; set; }
    }

    public sealed class DatoraActivationResult
    {
        public DatoraActivationResult() { }

        public DatoraActivationResult(int id, string state)
        {
            Id = id;
            State = state;
        }

        public int Id { get; set; }
        public string State { get; set; } = null!;
    }

    /// <summary>Carrier notification recorded as portability evidence.</summary>
    public sealed class DatoraNotificationRequest
    {
        public DatoraNotificationRequest() { }

        public DatoraNotificationRequest(Guid contextId, Guid messageId, string direction, string did,
            string? protocol, string? status, string? reason, DateTime sentAtUtc, string? sourceMessageId = null)
        {
            ContextId = contextId;
            MessageId = messageId;
            Direction = direction;
            Did = did;
            Protocol = protocol;
            Status = status;
            Reason = reason;
            SentAtUtc = sentAtUtc;
            SourceMessageId = sourceMessageId;
        }

        public Guid ContextId { get; set; }
        public Guid MessageId { get; set; }
        public string Direction { get; set; } = null!;
        public string Did { get; set; } = null!;
        public string? Protocol { get; set; }
        public string? Status { get; set; }
        public string? Reason { get; set; }
        public DateTime SentAtUtc { get; set; }
        public string? SourceMessageId { get; set; }
    }

    public sealed class DatoraNotificationResult
    {
        public DatoraNotificationResult() { }

        public DatoraNotificationResult(Guid id, Guid contextId, string state, bool needsReview)
        {
            Id = id;
            ContextId = contextId;
            State = state;
            NeedsReview = needsReview;
        }

        public Guid Id { get; set; }
        public Guid ContextId { get; set; }
        public string State { get; set; } = null!;
        public bool NeedsReview { get; set; }
    }
}
