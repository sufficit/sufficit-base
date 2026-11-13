using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace Sufficit.Finance
{
    /// <summary>Fiscal work queue across all customers: received payments that still need a service invoice.</summary>
    public class FiscalPendingView
    {
        /// <summary>Start of the window (UTC).</summary>
        [JsonPropertyName("since")]
        public DateTime Since { get; set; }

        /// <summary>Totals per invoice type (null key = not classified).</summary>
        [JsonPropertyName("groups")]
        public List<FiscalReceiptGroup> Groups { get; set; } = new List<FiscalReceiptGroup>();

        /// <summary>One entry per customer with receipts in the window, most pending value first.</summary>
        [JsonPropertyName("customers")]
        public List<FiscalPendingCustomer> Customers { get; set; } = new List<FiscalPendingCustomer>();

        [JsonPropertyName("warnings")]
        public List<string> Warnings { get; set; } = new List<string>();
    }

    public class FiscalPendingCustomer
    {
        [JsonPropertyName("contextid")]
        public Guid ContextId { get; set; }

        [JsonPropertyName("title")]
        public string Title { get; set; } = string.Empty;

        /// <summary>Invoices to issue (pending or failed).</summary>
        [JsonPropertyName("pending")]
        public int Pending { get; set; }

        [JsonPropertyName("pendingvalue")]
        public decimal PendingValue { get; set; }

        /// <summary>Pending lines without an invoice type (operator decides).</summary>
        [JsonPropertyName("unclassified")]
        public int Unclassified { get; set; }

        /// <summary>Pending lines whose service or type was inferred (confirm before issuing).</summary>
        [JsonPropertyName("suggested")]
        public int Suggested { get; set; }

        [JsonPropertyName("failed")]
        public int Failed { get; set; }

        [JsonPropertyName("processing")]
        public int Processing { get; set; }

        [JsonPropertyName("issued")]
        public int Issued { get; set; }

        [JsonPropertyName("fees")]
        public decimal Fees { get; set; }
    }
}
