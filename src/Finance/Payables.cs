using System;
using System.Collections.Generic;

namespace Sufficit.Finance
{
    /// <summary>Settlement state of an account payable, derived from its active payments.</summary>
    public enum PayableStatus { Open = 1, Partial = 2, Paid = 3 }

    /// <summary>
    /// An account payable of the company (supplier bill, commission withdrawal invoice), with its payments
    /// (ledger rows in the account's own context) and attachments (storage objects owned by the account).
    /// </summary>
    public class Payable
    {
        public Guid Id { get; set; }

        /// <summary>Company that owes (Sufficit's own context for "nossas contas").</summary>
        public Guid ContextId { get; set; }
        public Guid BeneficiaryId { get; set; }
        public string? BeneficiaryTitle { get; set; }
        public string? BeneficiaryDocument { get; set; }

        /// <summary>Text in the financial record convention: "Ação: objeto [MM/AAAA] {referência} (ORIGEM)".</summary>
        public string Description { get; set; } = string.Empty;
        public decimal Value { get; set; }
        public decimal Paid { get; set; }
        public decimal Remaining => Value - Paid;
        public PayableStatus Status { get; set; }
        public DateTime? DueUtc { get; set; }

        /// <summary>Supplier document reference, e.g. "NFS-e 4".</summary>
        public string? Reference { get; set; }
        public DateTime? CreatedUtc { get; set; }

        /// <summary>Optimistic concurrency: send it back on every change.</summary>
        public long Revision { get; set; }
        public List<PayablePayment> Payments { get; set; } = new List<PayablePayment>();
        public List<PayableAttachment> Attachments { get; set; } = new List<PayableAttachment>();
    }

    public class PayablePayment
    {
        public Guid Id { get; set; }
        public int Code { get; set; }
        public DateTime Timestamp { get; set; }
        public decimal Value { get; set; }
        public string Kind { get; set; } = string.Empty;
        public string? Description { get; set; }
        public string? Document { get; set; }
        public bool Active { get; set; }
    }

    public class PayableAttachment
    {
        public Guid Id { get; set; }
        public string? Title { get; set; }
        public string? MIME { get; set; }
        public ulong Length { get; set; }
    }

    public class PayableSearchParameters
    {
        /// <summary>Company that owes; null = Sufficit.</summary>
        public Guid? ContextId { get; set; }
        public PayableStatus? Status { get; set; }
        public Guid? BeneficiaryId { get; set; }
        public string? Text { get; set; }
    }

    /// <summary>Creates (Id empty) or changes an account payable.</summary>
    public class PayableSaveRequest
    {
        public Guid Id { get; set; }
        public Guid? ContextId { get; set; }
        public Guid BeneficiaryId { get; set; }
        public string Description { get; set; } = string.Empty;
        public decimal Value { get; set; }
        public DateTime? DueUtc { get; set; }
        public string? Reference { get; set; }

        /// <summary>Required for changes; null when creating.</summary>
        public long? ExpectedRevision { get; set; }
    }

    /// <summary>Records money paid on an account payable.</summary>
    public class PayablePaymentRequest
    {
        public Guid PayableId { get; set; }
        public long ExpectedRevision { get; set; }
        public decimal Value { get; set; }
        public DateTime? TimestampUtc { get; set; }

        /// <summary>"pix", "ted", "boleto" or "dinheiro".</summary>
        public string Method { get; set; } = "pix";

        /// <summary>Storage object of the payment receipt, already uploaded to the account.</summary>
        public Guid? ProofObjectId { get; set; }
    }
}
