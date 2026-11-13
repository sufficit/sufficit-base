using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace Sufficit.Finance
{
    /// <summary>
    ///     Fiscal consolidation of one customer: received payments in a window, split into
    ///     invoice lines by fiscal service type, each with its invoice state.
    /// </summary>
    public class FiscalReceiptsView
    {
        [JsonPropertyName("contextid")]
        public Guid ContextId { get; set; }

        /// <summary>Start of the window (UTC).</summary>
        [JsonPropertyName("since")]
        public DateTime Since { get; set; }

        /// <summary>Taker at the fiscal provider; null when the customer is not registered there.</summary>
        [JsonPropertyName("taker")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public FiscalTakerView? Taker { get; set; }

        /// <summary>Why issuing is blocked for this customer, when it is (pt-BR, user facing).</summary>
        [JsonPropertyName("blocker")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public string? Blocker { get; set; }

        [JsonPropertyName("groups")]
        public List<FiscalReceiptGroup> Groups { get; set; } = new List<FiscalReceiptGroup>();

        [JsonPropertyName("lines")]
        public List<FiscalReceiptLine> Lines { get; set; } = new List<FiscalReceiptLine>();

        /// <summary>Non blocking data issues found while reading sources (pt-BR, user facing).</summary>
        [JsonPropertyName("warnings")]
        public List<string> Warnings { get; set; } = new List<string>();
    }

    /// <summary>Totals of one fiscal service type (null key = not classified).</summary>
    public class FiscalReceiptGroup
    {
        [JsonPropertyName("servicekey")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public string? ServiceKey { get; set; }

        [JsonPropertyName("title")]
        public string Title { get; set; } = string.Empty;

        [JsonPropertyName("code")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public string? Code { get; set; }

        [JsonPropertyName("pending")]
        public int Pending { get; set; }

        [JsonPropertyName("pendingvalue")]
        public decimal PendingValue { get; set; }

        [JsonPropertyName("processing")]
        public int Processing { get; set; }

        [JsonPropertyName("issued")]
        public int Issued { get; set; }

        [JsonPropertyName("issuedvalue")]
        public decimal IssuedValue { get; set; }

        /// <summary>Provider issuing fees charged for the invoices of this group.</summary>
        [JsonPropertyName("fees")]
        public decimal Fees { get; set; }
    }

    /// <summary>Invoice line state derived from the provider invoice.</summary>
    public static class FiscalLineStatus
    {
        /// <summary>No active invoice: must be issued.</summary>
        public const string Pending = "pending";
        /// <summary>Scheduled or sent to the municipality, waiting authorization.</summary>
        public const string Processing = "processing";
        /// <summary>Authorized by the municipality.</summary>
        public const string Issued = "issued";
        /// <summary>Last attempt failed at the provider; must be issued again.</summary>
        public const string Failed = "failed";
    }

    /// <summary>One invoice to issue (or already issued): a received payment restricted to one fiscal type.</summary>
    public class FiscalReceiptLine
    {
        /// <summary>Idempotency reference used when issuing (e.g. receipt:{id}:technical-support).</summary>
        [JsonPropertyName("reference")]
        public string Reference { get; set; } = string.Empty;

        /// <summary>LEDGER (financial record) or ASAAS (provider payment without ledger record).</summary>
        [JsonPropertyName("source")]
        public string Source { get; set; } = string.Empty;

        /// <summary>Ledger record id, when sourced from the ledger.</summary>
        [JsonPropertyName("recordid")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public Guid? RecordId { get; set; }

        [JsonPropertyName("timestamp")]
        public DateTime Timestamp { get; set; }

        /// <summary>Payment method (Pix, Boleto, Cartão...).</summary>
        [JsonPropertyName("method")]
        public string Method { get; set; } = string.Empty;

        [JsonPropertyName("description")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public string? Description { get; set; }

        /// <summary>Full received amount.</summary>
        [JsonPropertyName("receiptvalue")]
        public decimal ReceiptValue { get; set; }

        /// <summary>Amount of this line (receipt items of this fiscal type).</summary>
        [JsonPropertyName("value")]
        public decimal Value { get; set; }

        [JsonPropertyName("servicekey")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public string? ServiceKey { get; set; }

        /// <summary>True when services were inferred (e.g. by amount) instead of an explicit link.</summary>
        [JsonPropertyName("suggested")]
        public bool Suggested { get; set; }

        [JsonPropertyName("services")]
        public List<FiscalReceiptService> Services { get; set; } = new List<FiscalReceiptService>();

        /// <summary>Provider payment (Asaas pay_...) when known; the invoice is bound to it.</summary>
        [JsonPropertyName("payment")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public string? Payment { get; set; }

        /// <summary>See <see cref="FiscalLineStatus"/>.</summary>
        [JsonPropertyName("status")]
        public string Status { get; set; } = FiscalLineStatus.Pending;

        [JsonPropertyName("invoice")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public FiscalIssueResult? Invoice { get; set; }

        /// <summary>Provider issuing fee charged for this invoice (from the provider statement), when known.</summary>
        [JsonPropertyName("fee")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public decimal? Fee { get; set; }
    }

    /// <summary>Contracted service paid by a receipt line.</summary>
    public class FiscalReceiptService
    {
        [JsonPropertyName("contractid")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public Guid? ContractId { get; set; }

        [JsonPropertyName("title")]
        public string Title { get; set; } = string.Empty;

        [JsonPropertyName("category")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public string? Category { get; set; }

        [JsonPropertyName("value")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public decimal? Value { get; set; }
    }
}
