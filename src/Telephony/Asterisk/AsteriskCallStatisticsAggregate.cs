using System;

namespace Sufficit.Telephony.Asterisk
{
    /// <summary>
    /// Totals for one account code over a period, computed by the database so that
    /// statistics jobs never have to pull the underlying call detail records.
    /// </summary>
    /// <remarks>
    /// One row per account code. A week that spans millions of records collapses to a
    /// few dozen of these, which is what keeps the statistics jobs inside their memory
    /// budget.
    ///
    /// Each metric counts <em>calls</em>, not records: records sharing a linkedid are one
    /// call, represented by its primary record (the greatest start, ties broken by the
    /// greatest sequence — the order the database already returns today).
    /// </remarks>
    public class AsteriskCallStatisticsAggregate
    {
        /// <summary>
        /// Raw account code as stored in the records. Callers translate it into a context
        /// id; values that do not parse belong to no client.
        /// </summary>
        public string AccountCode { get; set; } = string.Empty;

        /// <summary>Calls in the period for this account code.</summary>
        public int Total { get; set; }

        /// <summary>Calls whose primary record carries a DID.</summary>
        public int Incoming { get; set; }

        /// <summary>Calls with no DID but with a source number.</summary>
        public int Outbound { get; set; }

        /// <summary>Calls started Monday through Friday.</summary>
        public int WeekdayCalls { get; set; }

        /// <summary>Calls reporting a duration greater than zero.</summary>
        public int DurationCount { get; set; }

        /// <summary>
        /// Sum of those durations in seconds. Durations are whole seconds, so the total is
        /// exact in <see cref="double"/> well beyond any realistic call volume.
        /// </summary>
        public double DurationSum { get; set; }
    }
}
