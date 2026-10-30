using System;
using System.Collections.Generic;
using Sufficit.Operations;
namespace Sufficit.Sales;

/// <summary>
///     Collection notice the team must send to a customer. Created by the Sales module when a cadence notice
///     milestone is reached; anyone on the team may take it. Sending is still manual (e.g. Hermes) — the system
///     only records that it was sent, when, by whom and through which channel.
/// </summary>
public sealed class ServiceCollectionNotice
{
    public Guid ActivityId { get; set; }
    public Guid ContextId { get; set; }
    public OperationalActivityStatus Status { get; set; }
    public long Revision { get; set; }
    public string Title { get; set; } = string.Empty;
    public DateTime CreatedAtUtc { get; set; }
    public DateTime UpdatedAtUtc { get; set; }
    /// <summary>Who to charge and why, frozen when the notice was created.</summary>
    public ServiceCollectionNoticeState State { get; set; } = new();
    /// <summary>Last accepted operator: who sent the notice, or who canceled it (null for the system).</summary>
    public Guid? ActorId { get; set; }
    public string? CloseReason { get; set; }
}

/// <summary>Notice content persisted in the activity notes. Never accepted from clients.</summary>
public sealed class ServiceCollectionNoticeState
{
    public Guid ContractId { get; set; }
    public string ServiceTitle { get; set; } = string.Empty;
    public string? CustomerTitle { get; set; }
    public Guid? ResponsibleContextId { get; set; }
    public string? ResponsibleTitle { get; set; }
    public string? ResponsibleEmail { get; set; }
    public decimal? Amount { get; set; }
    public Guid CadenceId { get; set; }
    public Guid CaseId { get; set; }
    public Guid OccurrenceId { get; set; }
    public string MilestoneKey { get; set; } = string.Empty;
    /// <summary>D0 of the case (end of paid coverage), yyyy-MM-dd.</summary>
    public string AnchorDate { get; set; } = string.Empty;
    /// <summary>Date the notice became due, yyyy-MM-dd.</summary>
    public string DueDate { get; set; } = string.Empty;
    public bool Late { get; set; }
    public ServiceCollectionNoticeDelivery? Sent { get; set; }
    /// <summary>Display name of whoever sent or discarded the notice, from the authenticated session (or the agent).</summary>
    public string? HandledByName { get; set; }
}

/// <summary>Operator-declared delivery; never provider delivery evidence.</summary>
public sealed class ServiceCollectionNoticeDelivery
{
    /// <summary>WhatsApp, Email, Phone or Other.</summary>
    public string Channel { get; set; } = string.Empty;
    public DateTime SentAtUtc { get; set; }
    public string? Notes { get; set; }
    /// <summary>Optional message link or identifier (e.g. Hermes conversation).</summary>
    public string? MessageReference { get; set; }
}

/// <summary>Marks a notice as sent. The authenticated user is the sender.</summary>
public sealed class ServiceCollectionNoticeSentCommand
{
    public Guid RequestId { get; set; }
    public Guid ActivityId { get; set; }
    public Guid ContextId { get; set; }
    public long ExpectedRevision { get; set; }
    public string Channel { get; set; } = string.Empty;
    public DateTime SentAtUtc { get; set; }
    public string? Notes { get; set; }
    public string? MessageReference { get; set; }
}

/// <summary>Discards a notice that must not be sent (e.g. customer already paid by other means).</summary>
public sealed class ServiceCollectionNoticeCancelCommand
{
    public Guid RequestId { get; set; }
    public Guid ActivityId { get; set; }
    public Guid ContextId { get; set; }
    public long ExpectedRevision { get; set; }
    public string Reason { get; set; } = string.Empty;
}

public sealed class ServiceCollectionNoticePage
{
    public List<ServiceCollectionNotice> Items { get; set; } = new();
    /// <summary>True when more items exist than were returned.</summary>
    public bool Truncated { get; set; }
}
