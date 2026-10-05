using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Sufficit.Sales;

/// <summary>Authorized application boundary for resuming exhausted event transport.</summary>
public interface ISalesIntegrationRetryWriter
{
    /// <summary>Records the trusted requester and resumes one suspended delivery atomically.</summary>
    Task<SalesIntegrationRetryReceipt> RetryIntegrationDelivery(SalesIntegrationRetryRequest request, Guid requesterId, CancellationToken cancellationToken);
}

/// <summary>Idempotent command; never changes the original event or retries a permanent rejection.</summary>
public sealed class SalesIntegrationRetryRequest
{
    /// <summary>Caller-generated identity retained across uncertain HTTP outcomes.</summary>
    public Guid RequestId { get; set; }
    /// <summary>Explicit customer context owning the immutable event.</summary>
    public Guid ContextId { get; set; }
    /// <summary>Original event identity to resume, not a newly generated event.</summary>
    public Guid EventId { get; set; }
    /// <summary>Supported durable receiver; currently telephony-coverage-v1 only.</summary>
    public string Subscriber { get; set; } = string.Empty;
    /// <summary>Monotonic claim count observed before requesting a new retry cycle.</summary>
    public int ExpectedAttemptCount { get; set; }
    /// <summary>Required review reason; credentials and customer payloads must not be included.</summary>
    public string Reason { get; set; } = string.Empty;

    /// <summary>Rejects incomplete, unsupported or unbounded commands before persistence.</summary>
    public void Validate()
    {
        if (RequestId == Guid.Empty || ContextId == Guid.Empty || EventId == Guid.Empty ||
            Subscriber != "telephony-coverage-v1" || ExpectedAttemptCount < 10 ||
            ExpectedAttemptCount > int.MaxValue - 10 || string.IsNullOrWhiteSpace(Reason) ||
            Reason.Length > 512 || Reason != Reason.Trim() || Reason.Any(char.IsControl))
            throw new ArgumentException("Invalid sales integration retry request.");
    }
}

/// <summary>Immutable evidence of an accepted retry, independent of later transport success.</summary>
public sealed class SalesIntegrationRetryReceipt
{
    /// <summary>Stable identity of the accepted command.</summary>
    public Guid RequestId { get; set; }
    /// <summary>Customer context owning the retried event.</summary>
    public Guid ContextId { get; set; }
    /// <summary>Original immutable event identity.</summary>
    public Guid EventId { get; set; }
    /// <summary>Original operation correlation, preserved rather than regenerated.</summary>
    public Guid CorrelationId { get; set; }
    /// <summary>Durable transport subscriber whose attempt cycle was resumed.</summary>
    public string Subscriber { get; set; } = string.Empty;
    /// <summary>Authenticated command requester; not an invented original event author.</summary>
    public Guid RequesterId { get; set; }
    /// <summary>Original claim count retained at the start of the new bounded cycle.</summary>
    public int PreviousAttemptCount { get; set; }
    /// <summary>Immutable requester-supplied review reason.</summary>
    public string Reason { get; set; } = string.Empty;
    /// <summary>Server-generated acceptance instant in UTC.</summary>
    public DateTime RecordedAtUtc { get; set; }
}
