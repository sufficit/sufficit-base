using System;

namespace Sufficit.Operations
{
/// <summary>Exact revisions and explicit schedule; authenticated actor is supplied by the server.</summary>
public sealed class ReminderPolicyRequest
{
    /// <summary>Customer context owning the activity.</summary>
    public Guid ContextId { get; set; }
    /// <summary>Expected current activity revision, including assignment and deadline changes.</summary>
    public long ActivityRevision { get; set; }
    /// <summary>Expected current policy revision; zero creates its first configuration.</summary>
    public long PolicyRevision { get; set; }
    /// <summary>Explicit reminder scheduling decision.</summary>
    public bool Enabled { get; set; }
    /// <summary>First eligible occurrence, expressed in UTC.</summary>
    public DateTime FirstAtUtc { get; set; }
}

/// <summary>Investigated uncertain transport outcome; suppression disables scheduling without resending.</summary>
public sealed class ReminderResolutionRequest
{
    /// <summary>Customer context owning the occurrence.</summary>
    public Guid ContextId { get; set; }
    /// <summary>Expected retained occurrence revision.</summary>
    public long ReceiptRevision { get; set; }
    /// <summary>Expected current policy revision.</summary>
    public long PolicyRevision { get; set; }
    /// <summary>Whether the investigation established broker acceptance, not recipient delivery.</summary>
    public bool Accepted { get; set; }
    /// <summary>Required investigation reference without credentials or message contents.</summary>
    public string Evidence { get; set; } = string.Empty;
}

}
