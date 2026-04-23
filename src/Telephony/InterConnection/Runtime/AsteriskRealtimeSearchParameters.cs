using System;

namespace Sufficit.Telephony.InterConnection.Runtime
{
    /// <summary>
    ///     Base search contract for realtime provider families.
    ///     Providers should expose one primary <c>Search(...)</c> entrypoint and
    ///     keep simpler helpers as extension methods on top of this contract.
    /// </summary>
    public class AsteriskRealtimeSearchParameters : SearchParameters
    {
        /// <summary>
        ///     Exact runtime id to resolve.
        /// </summary>
        public string? Id { get; set; }

        /// <summary>
        ///     Runtime id prefix used for bulk bootstrap and prefix-based reads.
        /// </summary>
        public string? IdPrefix { get; set; }

        /// <summary>
        ///     Tri-state deleted filter.
        ///     <para><see langword="null"/>: keep current provider defaults.</para>
        ///     <para><see langword="false"/>: active rows only.</para>
        ///     <para><see langword="true"/>: tombstones/deleted rows only.</para>
        /// </summary>
        public bool? Deleted { get; set; }

        /// <summary>
        ///     Timestamp filters for incremental refresh windows.
        ///     Runtime sync currently drives deltas with <c>UpdatedAtUtc</c>
        ///     and <c>DeletedAtUtc</c>; providers may still honor
        ///     <c>CreatedAtUtc</c> for full temporal searches.
        /// </summary>
        public TimestampFilter? Timestamp { get; set; }
    }

    public sealed class AsteriskRealtimeEndPointSearchParameters : AsteriskRealtimeSearchParameters
    {
        public string? MailBoxesNotEqual { get; set; }
    }

    public sealed class AsteriskRealtimeAorSearchParameters : AsteriskRealtimeSearchParameters
    {
        public string? ContactNotEqual { get; set; }
    }

    public sealed class AsteriskRealtimeIdentifySearchParameters : AsteriskRealtimeSearchParameters
    {
        /// <summary>
        ///     Runtime endpoint id bound by the identify family.
        /// </summary>
        public string? Endpoint { get; set; }
    }

    public sealed class AsteriskRealtimeRegistrationSearchParameters : AsteriskRealtimeSearchParameters
    {
        /// <summary>
        ///     Canonical Asterisk <c>systemname</c> that owns the registration
        ///     projection on the local node, e.g. <c>apoint</c> or <c>google</c>.
        /// </summary>
        public string? NodeSystemName { get; set; }
    }

    public sealed class AsteriskRealtimeContactSearchParameters : AsteriskRealtimeSearchParameters
    {
        public uint? ExpirationTimeLessOrEqual { get; set; }

        public string? Uri { get; set; }

        public string? Endpoint { get; set; }

        public string? UserAgent { get; set; }

        public string? NodeSystemName { get; set; }
    }
}
