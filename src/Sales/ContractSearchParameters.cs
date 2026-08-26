using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations.Schema;
using System.Runtime.Serialization;
using System.Text;
using System.Text.Json.Serialization;

namespace Sufficit.Sales
{
    /// <summary>
    ///     Search filters for recurring contracts.
    /// </summary>
    public class ContractSearchParameters : ILimit
    {
        /// <summary>
        ///     Tenant or customer context identifier filter.
        /// </summary>
        public Guid? ContextId { get; set; }

        /// <summary>
        ///     External or business key filter.
        /// </summary>
        public TextFilter? Key { get; set; }

        /// <inheritdoc cref="ILimit.Limit"/>
        [DataMember(Name = "limit", IsRequired = false, Order = 1)]
        [Column("limit")]
        [JsonPropertyName("limit")]
        [DefaultValue((uint)0)]
        public uint? Limit { get; set; }

        /// <summary>
        ///     Filter by contract lifecycle status.
        /// </summary>
        public ContractStatus? Status { get; set; }

        /// <summary>
        ///     Filters contracts by their source system.
        /// </summary>
        public ContractSource? Source { get; set; }

        /// <summary>
        ///     Stable reconciliation key supplied by the source system.
        /// </summary>
        public string? SourceKey { get; set; }

        /// <summary>
        ///     Filters contracts by automatic processing readiness.
        /// </summary>
        public bool? AutomationEnabled { get; set; }

        /// <summary>Filter for contract start range</summary>
        public DateTimeRange? Start { get; set; }

        /// <summary>Filter for contract end range</summary>
        public DateTimeRange? Expiration { get; set; }

        /// <summary>
        ///     Friendly title filter.
        /// </summary>
        public TextFilter? Filter { get; set; }

        /// <summary>
        ///     Filters active or inactive contracts according to current date.
        /// </summary>
        public bool? Active { get; set; }
    }
}
