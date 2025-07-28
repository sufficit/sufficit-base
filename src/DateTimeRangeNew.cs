using System;
using System.Text;
using System.Text.Json.Serialization;
using static Sufficit.Constants;

namespace Sufficit
{
    /// <summary>
    ///     Ranged Date/Time Interval, prefer UTC
    /// </summary>
    public class DateTimeRangeNew : IEquatable<DateTimeRangeNew>
    {
        #region Constructors

        /// <summary>
        ///     Default constructor
        /// </summary>
        public DateTimeRangeNew() { }

        /// <summary>
        ///     Constructor for range
        /// </summary>
        /// <param name="start">Start date and time</param>
        /// <param name="end">End date and time</param>
        /// <param name="inclusive">Range inclusivity</param>
        public DateTimeRangeNew(DateTime? start, DateTime? end, RangeInclusive inclusive = RangeInclusive.BOTH)
        {
            Start = start;
            End = end;
            Inclusive = inclusive;
        }

        /// <summary>
        ///     Constructor for exact match
        /// </summary>
        /// <param name="exact">Exact date and time</param>
        public DateTimeRangeNew(DateTime exact)
        {
            Exact = exact;
        }

        #endregion

        #region Properties

        /// <summary>
        ///     Start date and time to filter
        /// </summary>
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull | JsonIgnoreCondition.WhenWritingDefault)]
        [JsonPropertyName("start")]
        [DateTimeKind(DateTimeKind.Utc)]
        public DateTime? Start { get; set; }

        /// <summary>
        ///     End, limit date and time to filter
        /// </summary>
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull | JsonIgnoreCondition.WhenWritingDefault)]
        [JsonPropertyName("end")]
        [DateTimeKind(DateTimeKind.Utc)]
        public DateTime? End { get; set; }

        /// <summary>
        ///     Exact match, ignoring "start" and "end" values
        /// </summary>
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull | JsonIgnoreCondition.WhenWritingDefault)]
        [JsonPropertyName("exact")]
        [DateTimeKind(DateTimeKind.Utc)]
        public DateTime? Exact { get; set; }

        /// <summary>
        ///     Use inclusive range, greater/less than or equals, or just greater/less than comparisons
        /// </summary>
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingDefault)]
        [JsonPropertyName("inclusive")]
        public RangeInclusive Inclusive { get; set; }

        #endregion

        #region Computed Properties

        /// <summary>
        ///     Indicates if this range represents an exact match
        /// </summary>
        [JsonIgnore]
        public bool IsExact => Exact.HasValue;

        /// <summary>
        ///     Indicates if this range has valid boundaries
        /// </summary>
        [JsonIgnore]
        public bool IsValid => IsExact || Start.HasValue || End.HasValue;

        /// <summary>
        ///     Gets the effective start time (UTC)
        /// </summary>
        [JsonIgnore]
        public DateTime? EffectiveStart => IsExact ? Exact : Start;

        /// <summary>
        ///     Gets the effective end time (UTC)
        /// </summary>
        [JsonIgnore]
        public DateTime? EffectiveEnd => IsExact ? Exact : End;

        #endregion

        #region Object Overrides

        public override string ToString()
        {
            if (Exact.HasValue)
                return Exact.Value.ToString(DATETIMEFORMAT);

            string result;
            if (Start.HasValue && End.HasValue)
                result = $"{Start.Value.ToString(DATETIMEFORMAT)} => {End.Value.ToString(DATETIMEFORMAT)}";
            else if (Start.HasValue)
                result = $"{Start.Value.ToString(DATETIMEFORMAT)} => ?";
            else if (End.HasValue)
                result = $"? => {End.Value.ToString(DATETIMEFORMAT)}";
            else
                result = "? => ?";

            if (Inclusive != RangeInclusive.NONE)
                result += $", {Inclusive.ToString().ToLowerInvariant()}";

            return result;
        }

        public override bool Equals(object? obj)
            => obj is DateTimeRangeNew other && Equals(other);

        public bool Equals(DateTimeRangeNew? other)
        {
            if (other is null) return false;
            if (ReferenceEquals(this, other)) return true;

            return Start == other.Start &&
                   End == other.End &&
                   Exact == other.Exact &&
                   Inclusive == other.Inclusive;
        }

        public override int GetHashCode()
        {
            unchecked
            {
                var hash = 17;
                hash = hash * 23 + (Start?.GetHashCode() ?? 0);
                hash = hash * 23 + (End?.GetHashCode() ?? 0);
                hash = hash * 23 + (Exact?.GetHashCode() ?? 0);
                hash = hash * 23 + Inclusive.GetHashCode();
                return hash;
            }
        }

        #endregion

        #region Operators

        public static bool operator ==(DateTimeRangeNew? left, DateTimeRangeNew? right)
            => Equals(left, right);

        public static bool operator !=(DateTimeRangeNew? left, DateTimeRangeNew? right)
            => !Equals(left, right);

        #endregion
    }
}
