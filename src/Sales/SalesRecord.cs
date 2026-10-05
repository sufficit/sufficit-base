using System;
using System.Text.Json.Serialization;

namespace Sufficit.Sales
{
    /// <summary>
    /// Represents a commercial record for a customer's purchased service or credit allocation,
    /// including its validity period, recorded price and commission information.
    /// </summary>
    /// <remarks>
    /// This is a customer transaction record, not a service catalog definition or a fiscal invoice.
    /// A renewal can create a successor record for a new validity period.
    /// </remarks>
    public class SalesRecord
    {
        /// <summary>Numeric reference assigned to the commercial record.</summary>
        public int Code { get; set; }

        /// <summary>Unique identifier of the commercial record.</summary>
        public Guid Id { get; set; }

        /// <summary>Identifier of the customer context that owns the service or credit allocation.</summary>
        public Guid ContextId { get; set; }

        /// <summary>Creation timestamp, which may differ from the start of the validity period.</summary>
        public DateTime Timestamp { get; set; }

        /// <summary>Start of the service or credit allocation's validity period.</summary>
        public DateTime Start { get; set; }

        /// <summary>End of the service or credit allocation's validity period.</summary>
        public DateTime End { get; set; }

        /// <summary>Billing date associated with the record, or null when no billing date is recorded.</summary>
        public DateTime? Billing { get; set; }

        /// <summary>Timestamp of the most recent recorded update.</summary>
        public DateTime Update { get; set; }

        /// <summary>Legacy numeric customer reference, or null when unavailable.</summary>
        /// <remarks>Use <see cref="ContextId"/> for the current customer identity. This reference is retained for historical traceability.</remarks>
        [JsonPropertyName("legacyCustomerCode")]
        public uint? LegacyCustomerCode { get; set; }

        /// <summary>Description of the purchased service or credit allocation.</summary>
        public string? Description { get; set; }

        /// <summary>Additional notes associated with the commercial record.</summary>
        public string? Extra { get; set; }

        /// <summary>Monetary value recorded for the service or credit allocation, or null when unspecified.</summary>
        public decimal? Value { get; set; }

        /// <summary>Indicates whether this record has been renewed into a successor record.</summary>
        public bool Renewed { get; set; }

        /// <summary>Full type name used to identify the service represented by the record.</summary>
        public string? Kind { get; set; }

        /// <summary>Identifier of the user associated with the commercial record.</summary>
        public Guid UserId { get; set; }

        /// <summary>Identifier of the commissioned party, or null when no party is assigned.</summary>
        public Guid? CommissionedId { get; set; }

        /// <summary>Commission value recorded for the commissioned party, or null when unspecified.</summary>
        public decimal? Commission { get; set; }
    }
}
