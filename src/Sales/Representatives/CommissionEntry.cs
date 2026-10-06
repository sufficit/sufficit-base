using System;
using System.Collections.Generic;

namespace Sufficit.Sales
{
    /// <summary>Statement line lifecycle: released on customer payment, then paid out or reversed.</summary>
    public enum CommissionEntryStatus { Released = 1, Paid = 2, Reversed = 3 }

    /// <summary>
    /// One commission statement line: a paid service period of a customer, attributed to one
    /// portfolio assignment. Unique per (service period, assignment).
    /// </summary>
    public class CommissionEntry
    {
        public Guid Id { get; set; }
        public Guid AssignmentId { get; set; }
        public Guid RepresentativeId { get; set; }
        public Guid CustomerId { get; set; }

        /// <summary>Service period (ledger document SERVICO:&lt;id&gt;).</summary>
        public Guid ServiceId { get; set; }

        /// <summary>Billing date of the period (ledger movement).</summary>
        public DateTime PeriodUtc { get; set; }

        /// <summary>Amount the customer paid for the period (after discounts).</summary>
        public decimal PaidValue { get; set; }

        public Guid PolicyId { get; set; }

        /// <summary>Share of the assignment applied (0 &lt; share ≤ 1).</summary>
        public decimal Share { get; set; }

        /// <summary>Commission due: policy result × share, in BRL.</summary>
        public decimal Amount { get; set; }

        public CommissionEntryStatus Status { get; set; } = CommissionEntryStatus.Released;
        public DateTime ReleasedUtc { get; set; }
        public DateTime? ReversedUtc { get; set; }
        public Guid? PayoutId { get; set; }

        /// <summary>Display only (not persisted).</summary>
        public string? CustomerTitle { get; set; }
    }

    /// <summary>Payout lifecycle. Pending only while the ledger credit is being written.</summary>
    public enum CommissionPayoutStatus { Pending = 1, Paid = 2 }

    /// <summary>
    /// A payment to a representative grouping released statement lines: balance credit in the
    /// system or PIX. PIX payouts require the signed RPA and the transfer proof attached.
    /// </summary>
    public class CommissionPayout
    {
        public Guid Id { get; set; }
        public Guid RepresentativeId { get; set; }
        public CommissionPayoutMethod Method { get; set; }
        public CommissionPayoutStatus Status { get; set; } = CommissionPayoutStatus.Pending;

        /// <summary>Sum of the grouped statement lines.</summary>
        public decimal Gross { get; set; }

        /// <summary>Withholdings informed by the operator (INSS/IRRF on the RPA); never computed here.</summary>
        public decimal Withholdings { get; set; }

        /// <summary>Gross minus withholdings: what the representative actually receives.</summary>
        public decimal Net { get; set; }

        /// <summary>Signed RPA (storage object).</summary>
        public Guid? ReceiptObjectId { get; set; }

        /// <summary>PIX transfer proof (storage object).</summary>
        public Guid? ProofObjectId { get; set; }

        /// <summary>Ledger credit for balance payouts.</summary>
        public Guid? LedgerRecordId { get; set; }

        public string? Notes { get; set; }
        public Guid CreatedBy { get; set; }
        public DateTime CreatedUtc { get; set; }
        public DateTime? PaidUtc { get; set; }
        public int Entries { get; set; }

        /// <summary>Display only (not persisted).</summary>
        public string? RepresentativeTitle { get; set; }
    }

    /// <summary>Pays released statement lines of one representative.</summary>
    public class CommissionPayoutRequest
    {
        public Guid RepresentativeId { get; set; }

        /// <summary>Released lines to pay; empty = every released line of the representative.</summary>
        public IList<Guid> EntryIds { get; set; } = new List<Guid>();

        public CommissionPayoutMethod Method { get; set; }
        public decimal Withholdings { get; set; }
        public Guid? ReceiptObjectId { get; set; }
        public Guid? ProofObjectId { get; set; }
        public string? Notes { get; set; }
    }
}
