using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace Sufficit.Sales;

/// <summary>Public read boundary for commercial integration evidence, without private event payloads.</summary>
public interface ISalesIntegrationAuditReader
{
    /// <summary>Reads an ordered page for exactly one customer stream without changing delivery state.</summary>
    Task<SalesIntegrationAuditPage> ReadIntegrationAudit(SalesIntegrationAuditSearch parameters, CancellationToken cancellationToken);
}

/// <summary>Context-scoped cursor parameters for commercial integration audit.</summary>
public sealed class SalesIntegrationAuditSearch
{
    /// <summary>Required customer context; an empty identifier never requests all customers.</summary>
    public Guid ContextId { get; set; }
    /// <summary>Exclusive customer stream version cursor; zero starts at the first event.</summary>
    public long AfterVersion { get; set; }
    /// <summary>Optional operation correlation, restricted to the requested customer context.</summary>
    public Guid? CorrelationId { get; set; }
    /// <summary>Maximum event rows in the page, between one and one hundred.</summary>
    public int Limit { get; set; } = 50;

    /// <summary>Rejects unbounded or ambiguous audit queries before persistence access.</summary>
    public void Validate()
    {
        if (ContextId == Guid.Empty || AfterVersion < 0 || Limit < 1 || Limit > 100 || CorrelationId == Guid.Empty)
            throw new ArgumentException("Invalid sales integration audit query.");
    }
}

/// <summary>Ordered event page; subscriber transport state may advance during the read.</summary>
public sealed class SalesIntegrationAuditPage
{
    /// <summary>Requested customer context, including for an empty result.</summary>
    public Guid ContextId { get; set; }
    /// <summary>Event metadata and transport evidence; excludes private event payloads.</summary>
    public List<SalesIntegrationAuditEntry> Items { get; set; } = new();
    /// <summary>Exclusive cursor for the next page, or null when no additional row was observed.</summary>
    public long? NextVersion { get; set; }
}

/// <summary>Immutable event identity accompanied by current per-subscriber transport evidence.</summary>
public sealed class SalesIntegrationAuditEntry
{
    /// <summary>Stable identity of the persisted event, preserved during retries.</summary>
    public Guid EventId { get; set; }
    /// <summary>Customer context that owns the event stream.</summary>
    public Guid ContextId { get; set; }
    /// <summary>Monotonic customer stream version; not a contract revision or schema version.</summary>
    public long StreamVersion { get; set; }
    /// <summary>Original public event type, including its declared version suffix.</summary>
    public string EventType { get; set; } = string.Empty;
    /// <summary>Identifier connecting events emitted by the same commercial operation.</summary>
    public Guid CorrelationId { get; set; }
    /// <summary>Original event occurrence instant in UTC.</summary>
    public DateTime OccurredAtUtc { get; set; }
    /// <summary>Recorded subscriber states; empty means no recorded delivery attempt.</summary>
    public List<SalesIntegrationDeliverySummary> Deliveries { get; set; } = new();
}

/// <summary>Transport evidence only; successful storage is not operational completion.</summary>
public sealed class SalesIntegrationDeliverySummary
{
    /// <summary>Stable consumer identity used in its event receipt key.</summary>
    public string Subscriber { get; set; } = string.Empty;
    /// <summary>Persisted transport status: pending, stored, rejected or suspended.</summary>
    public string DeliveryStatus { get; set; } = string.Empty;
    /// <summary>Number of delivery claims, including recovered expired leases.</summary>
    public int AttemptCount { get; set; }
    /// <summary>Earliest retry availability in UTC; not a promised provisioning time.</summary>
    public DateTime AvailableAtUtc { get; set; }
    /// <summary>Current lease expiry in UTC, or null when no lease is held.</summary>
    public DateTime? LeaseUntilUtc { get; set; }
    /// <summary>Most recently recorded transport result, or null when no audit record exists.</summary>
    public string? LastResult { get; set; }
    /// <summary>Latest accepted manual retry, including its authenticated requester and review reason.</summary>
    public SalesIntegrationRetryReceipt? LastRetry { get; set; }
    /// <summary>UTC instant of the latest audit record; may be newer than the event itself.</summary>
    public DateTime? LastRecordedAtUtc { get; set; }
}
