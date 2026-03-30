using System;

namespace Sufficit.Sales
{
    /// <summary>
    ///     Registered interruption interval for a recurring contract.
    /// </summary>
    public class ContractInterruption
    {
        /// <summary>
        ///     Interruption identifier.
        /// </summary>
        public Guid Id { get; set; }

        /// <summary>
        ///     Parent contract identifier.
        /// </summary>
        public Guid ContractId { get; set; }

        /// <summary>
        ///     Tenant or customer context identifier.
        /// </summary>
        public Guid ContextId { get; set; }

        /// <summary>
        ///     Semantic interruption type.
        /// </summary>
        public ContractInterruptionType Type { get; set; } = ContractInterruptionType.Pause;

        /// <summary>
        ///     Inclusive start date of the interruption.
        /// </summary>
        public DateTime Start { get; set; }

        /// <summary>
        ///     Exclusive end date of the interruption. Null means still open.
        /// </summary>
        public DateTime? End { get; set; }

        /// <summary>
        ///     Indicates if the interruption should create billing credits.
        /// </summary>
        public bool AffectsBilling { get; set; } = true;

        /// <summary>
        ///     Short reason visible to operators and customers when needed.
        /// </summary>
        public string? Reason { get; set; }

        /// <summary>
        ///     Additional internal notes.
        /// </summary>
        public string? Notes { get; set; }

        /// <summary>
        ///     Operator responsible for creating the interruption.
        /// </summary>
        public Guid? CreatedByUserId { get; set; }

        /// <summary>
        ///     UTC creation timestamp.
        /// </summary>
        public DateTime CreatedAtUtc { get; set; } = DateTime.UtcNow;

        /// <summary>
        ///     UTC update timestamp.
        /// </summary>
        public DateTime UpdatedAtUtc { get; set; } = DateTime.UtcNow;
    }
}
