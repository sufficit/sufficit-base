using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using static Sufficit.Constants;

namespace Sufficit
{
    /// <summary>
    ///     Ranged Numeric Interval for numeric types
    /// </summary>
    /// <typeparam name="T">Numeric type (decimal, int, double, etc.)</typeparam>
    public class NumericRange<T> : IEquatable<NumericRange<T>> where T : struct, IComparable<T>
    {
        #region Constructors

        /// <summary>
        ///     Default constructor
        /// </summary>
        public NumericRange() { }

        /// <summary>
        ///     Constructor for range
        /// </summary>
        /// <param name="start">Start value</param>
        /// <param name="end">End value</param>
        /// <param name="inclusive">Range inclusivity</param>
        public NumericRange(T? start, T? end, RangeInclusive inclusive = RangeInclusive.BOTH)
        {
            Start = start;
            End = end;
            Inclusive = inclusive;
        }

        /// <summary>
        ///     Constructor for exact match
        /// </summary>
        /// <param name="exact">Exact value</param>
        public NumericRange(T exact)
        {
            Exact = exact;
        }

        #endregion

        #region Properties

        /// <summary>
        ///     Start value to filter
        /// </summary>
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull | JsonIgnoreCondition.WhenWritingDefault)]
        [JsonPropertyName("start")]
        public T? Start { get; set; }

        /// <summary>
        ///     End, limit value to filter
        /// </summary>
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull | JsonIgnoreCondition.WhenWritingDefault)]
        [JsonPropertyName("end")]
        public T? End { get; set; }

        /// <summary>
        ///     Exact match, ignoring "start" and "end" values
        /// </summary>
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull | JsonIgnoreCondition.WhenWritingDefault)]
        [JsonPropertyName("exact")]
        public T? Exact { get; set; }

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
        ///     Gets the effective start value
        /// </summary>
        [JsonIgnore]
        public T? EffectiveStart => IsExact ? Exact : Start;

        /// <summary>
        ///     Gets the effective end value
        /// </summary>
        [JsonIgnore]
        public T? EffectiveEnd => IsExact ? Exact : End;

        #endregion

        #region Object Overrides

        public override string ToString()
        {
            if (Exact.HasValue)
                return Exact.Value.ToString() ?? string.Empty;

            string result;
            if (Start.HasValue && End.HasValue)
                result = $"{Start.Value} => {End.Value}";
            else if (Start.HasValue)
                result = $"{Start.Value} => ?";
            else if (End.HasValue)
                result = $"? => {End.Value}";
            else
                result = "? => ?";

            if (Inclusive != RangeInclusive.NONE)
                result += $", {Inclusive.ToString().ToLowerInvariant()}";

            return result;
        }

        public override bool Equals(object? obj)
            => obj is NumericRange<T> other && Equals(other);

        public bool Equals(NumericRange<T>? other)
        {
            if (other is null) return false;
            if (ReferenceEquals(this, other)) return true;

            return EqualityComparer<T?>.Default.Equals(Start, other.Start) &&
                   EqualityComparer<T?>.Default.Equals(End, other.End) &&
                   EqualityComparer<T?>.Default.Equals(Exact, other.Exact) &&
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

        public static bool operator ==(NumericRange<T>? left, NumericRange<T>? right)
            => Equals(left, right);

        public static bool operator !=(NumericRange<T>? left, NumericRange<T>? right)
            => !Equals(left, right);

        #endregion
    }

    /// <summary>
    /// Type alias for decimal numeric ranges
    /// </summary>
    public class DecimalRange : NumericRange<decimal>
    {
        public DecimalRange() : base() { }
        public DecimalRange(decimal? start, decimal? end, RangeInclusive inclusive = RangeInclusive.BOTH) : base(start, end, inclusive) { }
        public DecimalRange(decimal exact) : base(exact) { }
    }

    /// <summary>
    /// Type alias for integer numeric ranges
    /// </summary>
    public class IntRange : NumericRange<int>
    {
        public IntRange() : base() { }
        public IntRange(int? start, int? end, RangeInclusive inclusive = RangeInclusive.BOTH) : base(start, end, inclusive) { }
        public IntRange(int exact) : base(exact) { }
    }

    /// <summary>
    /// Type alias for double numeric ranges
    /// </summary>
    public class DoubleRange : NumericRange<double>
    {
        public DoubleRange() : base() { }
        public DoubleRange(double? start, double? end, RangeInclusive inclusive = RangeInclusive.BOTH) : base(start, end, inclusive) { }
        public DoubleRange(double exact) : base(exact) { }
    }
}
