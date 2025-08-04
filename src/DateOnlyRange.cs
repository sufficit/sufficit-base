using System;
using System.Text;
using System.Text.Json.Serialization;

namespace Sufficit
{
    /// <summary>
    ///     Ranged Date Interval for DateOnly values
    /// </summary>
    public class DateOnlyRange : IEquatable<DateOnlyRange>
    {
        #region Constructors

        /// <summary>
        ///     Default constructor
        /// </summary>
        public DateOnlyRange() { }

        /// <summary>
        ///     Constructor for range
        /// </summary>
        /// <param name="start">Start date</param>
        /// <param name="end">End date</param>
        /// <param name="inclusive">Range inclusivity</param>
        public DateOnlyRange(DateOnly? start, DateOnly? end, RangeInclusive inclusive = RangeInclusive.BOTH)
        {
            Start = start;
            End = end;
            Inclusive = inclusive;
        }

        /// <summary>
        ///     Constructor for exact match
        /// </summary>
        /// <param name="exact">Exact date</param>
        public DateOnlyRange(DateOnly exact)
        {
            Exact = exact;
        }

        #endregion

        #region Properties

        /// <summary>
        ///     Start date to filter
        /// </summary>
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull | JsonIgnoreCondition.WhenWritingDefault)]
        [JsonPropertyName("start")]
        public DateOnly? Start { get; set; }

        /// <summary>
        ///     End, limit date to filter
        /// </summary>
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull | JsonIgnoreCondition.WhenWritingDefault)]
        [JsonPropertyName("end")]
        public DateOnly? End { get; set; }

        /// <summary>
        ///     Exact match, ignoring "start" and "end" values
        /// </summary>
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull | JsonIgnoreCondition.WhenWritingDefault)]
        [JsonPropertyName("exact")]
        public DateOnly? Exact { get; set; }

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
        ///     Gets the effective start date
        /// </summary>
        [JsonIgnore]
        public DateOnly? EffectiveStart => IsExact ? Exact : Start;

        /// <summary>
        ///     Gets the effective end date
        /// </summary>
        [JsonIgnore]
        public DateOnly? EffectiveEnd => IsExact ? Exact : End;

        #endregion

        #region Object Overrides

        public override string ToString()
        {
            const string dateFormat = "yyyy-MM-dd";
            
            if (Exact.HasValue)
                return Exact.Value.ToString(dateFormat);

            string result;
            if (Start.HasValue && End.HasValue)
                result = $"{Start.Value.ToString(dateFormat)} => {End.Value.ToString(dateFormat)}";
            else if (Start.HasValue)
                result = $"{Start.Value.ToString(dateFormat)} => ?";
            else if (End.HasValue)
                result = $"? => {End.Value.ToString(dateFormat)}";
            else
                result = "? => ?";

            if (Inclusive != RangeInclusive.NONE)
                result += $", {Inclusive.ToString().ToLowerInvariant()}";

            return result;
        }

        public override bool Equals(object? obj)
            => obj is DateOnlyRange other && Equals(other);

        public bool Equals(DateOnlyRange? other)
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

        public static bool operator ==(DateOnlyRange? left, DateOnlyRange? right)
            => Equals(left, right);

        public static bool operator !=(DateOnlyRange? left, DateOnlyRange? right)
            => !Equals(left, right);

        #endregion
    }
}
