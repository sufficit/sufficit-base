namespace Sufficit
{
    /// <summary>
    /// Common interface for logical incremental synchronization predicates.
    /// Use by runtime refresh pipelines and search parameter DTOs to enable
    /// tri-state deletion filtering and timestamp-windowed queries.
    /// </summary>
    public interface IIncrementalTrackingSearchParameters
    {
        /// <summary>
        /// Tri-state deleted filter.
        /// <para><see langword="null"/>: no deleted-state filter.</para>
        /// <para><see langword="false"/>: active records only (not soft-deleted).</para>
        /// <para><see langword="true"/>: soft-deleted records only.</para>
        /// </summary>
        bool? Deleted { get; set; }

        /// <summary>
        /// Logical incremental synchronization window.
        /// Consumers should use <c>UpdatedAtUtc</c> for active mutations and
        /// <c>DeletedAtUtc</c> for tombstones when building provider predicates.
        /// </summary>
        TimestampFilter? Timestamp { get; set; }
    }
}
