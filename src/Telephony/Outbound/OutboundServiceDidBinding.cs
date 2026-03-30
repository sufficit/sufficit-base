using System;

namespace Sufficit.Telephony.Outbound
{
    /// <summary>
    ///     Explicit smart DID binding stored in the outbound experimental catalog.
    /// </summary>
    public class OutboundServiceDidBinding
    {
        /// <summary>
        ///     Unique identifier of the binding row.
        /// </summary>
        public Guid Id { get; set; }

        /// <summary>
        ///     Assignment that owns this DID row.
        /// </summary>
        public Guid AssignmentId { get; set; }

        /// <summary>
        ///     Optional reference to a canonical DID row.
        /// </summary>
        public Guid? DidId { get; set; }

        /// <summary>
        ///     Outbound number to present when this row is selected.
        /// </summary>
        public string DidNumber { get; set; } = string.Empty;

        /// <summary>
        ///     Optional operator label.
        /// </summary>
        public string? Title { get; set; }

        /// <summary>
        ///     Optional destination area code hint used for nearest-DID selection.
        /// </summary>
        public string? AreaCode { get; set; }

        /// <summary>
        ///     Lower values win.
        /// </summary>
        public int Priority { get; set; } = 100;

        /// <summary>
        ///     Enablement flag.
        /// </summary>
        public bool Enabled { get; set; } = true;

        /// <summary>
        ///     Free-form operator notes.
        /// </summary>
        public string? Comments { get; set; }

        public DateTime CreatedAtUtc { get; set; }

        public DateTime? UpdatedAtUtc { get; set; }
    }
}
