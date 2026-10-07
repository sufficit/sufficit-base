using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using System.Text.Json.Serialization;
using System.Threading;
using System.Threading.Tasks;

namespace Sufficit.Sales;

/// <summary>Commercial customer classification, independent of contracts, billing and contact tags.</summary>
public enum CustomerStatus { Unclassified = 0, Active = 1, Pending = 2, Closing = 3, Canceled = 4 }

/// <summary>Distinguishes initial migration evidence from an operator-owned state.</summary>
public enum CustomerStatusOrigin { Spreadsheet = 0, Operator = 1 }

/// <summary>Effective server capability for the currently authenticated customer context.</summary>
public sealed class CustomerStatusCapabilities
{
    /// <summary>Exact authorized customer identity.</summary>
    public Guid ContextId { get; set; }
    /// <summary>True only when both the operations gate and caller permission allow changes.</summary>
    public bool CanChange { get; set; }
}

/// <summary>Read-only spreadsheet evidence reviewed before applying a customer classification.</summary>
public sealed class CustomerStatusSource
{
    /// <summary>Stable Google spreadsheet identity, not an authenticated URL.</summary>
    public string SpreadsheetId { get; set; } = string.Empty;
    /// <summary>Original worksheet name, including meaningful whitespace.</summary>
    public string SheetName { get; set; } = string.Empty;
    /// <summary>Original situation cell in A1 notation.</summary>
    public string Cell { get; set; } = string.Empty;
    /// <summary>Original spreadsheet classification, retained without normalization.</summary>
    public string Value { get; set; } = string.Empty;
    /// <summary>Uppercase SHA-256 of the exact reviewed source file.</summary>
    public string FileHash { get; set; } = string.Empty;

    /// <summary>Validates bounded provenance and rejects unknown classifications.</summary>
    public CustomerStatus Validate()
    {
        if (!Regex.IsMatch(SpreadsheetId ?? "", @"^[A-Za-z0-9_-]{1,128}$") ||
            string.IsNullOrWhiteSpace(SheetName) || SheetName.Length > 128 || SheetName.Any(char.IsControl) ||
            !Regex.IsMatch(Cell ?? "", @"^B[1-9][0-9]{0,6}$") ||
            !Regex.IsMatch(FileHash ?? "", @"^[A-F0-9]{64}$") || Value == null || Value.Length > 64)
            throw new ArgumentException("Invalid spreadsheet status evidence.");
        switch (Value.Trim().ToUpperInvariant())
        {
            case "ATIVO": return CustomerStatus.Active;
            case "AGUARDANDO": return CustomerStatus.Pending;
            case "FINALIZANDO": return CustomerStatus.Closing;
            case "CANCELADO": return CustomerStatus.Canceled;
            default: throw new ArgumentException("Unknown spreadsheet customer status.");
        }
    }
}

/// <summary>Authoritative commercial state for an existing customer context.</summary>
public sealed class CustomerStatusRecord
{
    /// <summary>Existing customer identity; this record never creates a new contact.</summary>
    public Guid ContextId { get; set; }
    /// <summary>Current commercial classification declared by migration evidence or an authorized operator.</summary>
    public CustomerStatus Status { get; set; }
    /// <summary>Who owns the current classification; operator changes cannot be overwritten by imports.</summary>
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingDefault)]
    public CustomerStatusOrigin Origin { get; set; }
    /// <summary>Operator-declared event instant in UTC, separate from server recording time.</summary>
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingDefault)]
    public DateTime? EffectiveAtUtc { get; set; }

    /// <summary>Monotonic accepted state revision; zero means no imported classification.</summary>
    public long Revision { get; set; }
    /// <summary>Server application instant in UTC, not a historical cancellation date.</summary>
    public DateTime? ChangedAtUtc { get; set; }
    /// <summary>Authenticated operator who accepted the current state.</summary>
    public Guid? ActorId { get; set; }
    /// <summary>Reviewed migration evidence; null for an unclassified or operator-owned current state.</summary>
    public CustomerStatusSource? Source { get; set; }
}

/// <summary>Reviewed migration or operator command with explicit provenance and revision.</summary>
public sealed class CustomerStatusTransitionRequest
{
    /// <summary>Stable request identity retained across uncertain HTTP outcomes.</summary>
    public Guid RequestId { get; set; }
    /// <summary>Verified existing customer context.</summary>
    public Guid ContextId { get; set; }
    /// <summary>Exact current revision; zero creates the initial classification.</summary>
    public long ExpectedRevision { get; set; }
    /// <summary>Desired classification; migration commands must match the original spreadsheet value.</summary>
    public CustomerStatus Status { get; set; }
    /// <summary>Who owns the current classification; operator changes cannot be overwritten by imports.</summary>
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingDefault)]
    public CustomerStatusOrigin Origin { get; set; }
    /// <summary>Operator-declared event instant in UTC, separate from server recording time.</summary>
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingDefault)]
    public DateTime? EffectiveAtUtc { get; set; }

    /// <summary>Required operator review reason; never include credentials.</summary>
    public string Reason { get; set; } = string.Empty;
    /// <summary>Evidence of the exact reviewed migration source; must be null for operator changes.</summary>
    public CustomerStatusSource? Source { get; set; } = new CustomerStatusSource();

    /// <summary>Rejects missing identities, unbounded data and mismatched source classifications.</summary>
    public void Validate()
    {
        if (RequestId == Guid.Empty || ContextId == Guid.Empty || ExpectedRevision < 0 || ExpectedRevision == long.MaxValue ||
            string.IsNullOrWhiteSpace(Reason) || Reason.Length > 1000 || Reason.Any(char.IsControl) ||
            !Enum.IsDefined(typeof(CustomerStatusOrigin), Origin) ||
            (Origin == CustomerStatusOrigin.Spreadsheet ? Source == null || Status != Source.Validate() || EffectiveAtUtc.HasValue :
             Source != null || (Status != CustomerStatus.Active && Status != CustomerStatus.Canceled) ||
             !EffectiveAtUtc.HasValue || EffectiveAtUtc.Value.Kind != DateTimeKind.Utc ||
             EffectiveAtUtc.Value < new DateTime(2000, 1, 1, 0, 0, 0, DateTimeKind.Utc) ||
             EffectiveAtUtc.Value > DateTime.UtcNow.AddMinutes(1)))
            throw new ArgumentException("Invalid customer status command.");
    }
}

/// <summary>Immutable accepted command evidence, also retained when the classification did not change.</summary>
public sealed class CustomerStatusHistory
{
    /// <summary>Monotonic acceptance cursor within this customer, including no-change receipts.</summary>
    public long Sequence { get; set; }
    /// <summary>Accepted command identity.</summary>
    public Guid RequestId { get; set; }
    /// <summary>Authenticated server-derived actor.</summary>
    public Guid ActorId { get; set; }
    /// <summary>Operator review reason.</summary>
    public string Reason { get; set; } = string.Empty;
    /// <summary>Server acceptance instant, independent from the state change instant.</summary>
    public DateTime RecordedAtUtc { get; set; }
    /// <summary>True only when this command created or changed the state or its provenance.</summary>
    public bool Changed { get; set; }
    /// <summary>Previous state; null for initial import.</summary>
    public CustomerStatusRecord? Before { get; set; }
    /// <summary>Accepted historical state, independent of later updates.</summary>
    public CustomerStatusRecord After { get; set; } = new CustomerStatusRecord();
}

/// <summary>Sales-owned state commands and bounded context-scoped history.</summary>
public interface ICustomerStatusStore
{
    /// <summary>Returns an explicit unclassified record when the context has no imported state.</summary>
    Task<CustomerStatusRecord> Get(Guid contextId, CancellationToken token);
    /// <summary>Applies one exact revision or replays the immutable authenticated receipt.</summary>
    Task<CustomerStatusHistory> Apply(CustomerStatusTransitionRequest request, Guid actorId, CancellationToken token);
    /// <summary>Reads immutable receipts after an acceptance cursor with a bounded page size.</summary>
    Task<IReadOnlyList<CustomerStatusHistory>> History(Guid contextId, long afterSequence, int limit, CancellationToken token);
}

/// <summary>A stale revision or reused request identity must be reviewed before a new command.</summary>
public sealed class CustomerStatusConflictException : InvalidOperationException
{
    /// <summary>Creates a conflict with an optional provider error.</summary>
    public CustomerStatusConflictException(string message, Exception? inner = null) : base(message, inner) { }
}

/// <summary>Verifies the existing customer identity before accepting imported state.</summary>
public interface ICustomerStatusIdentityVerifier
{
    /// <summary>Returns true only for a currently existing contact with this exact identity.</summary>
    Task<bool> Exists(Guid contextId, CancellationToken token);
}
