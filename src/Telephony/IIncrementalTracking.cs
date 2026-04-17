using System;

namespace Sufficit.Telephony
{
    /// <summary>
    /// Minimal persistence tracking contract for telephony runtime families.
    /// Physical column names must stay mapped in Entity Framework.
    /// </summary>
    public interface IIncrementalTracking
    {
        /// <summary>
        /// Logical last-change watermark used by runtime refresh pipelines.
        /// </summary>
        DateTime Timestamp { get; set; }

        /// <summary>
        /// Logical soft-delete marker. Null means the row is active.
        /// </summary>
        DateTime? Deleted { get; set; }
    }
}