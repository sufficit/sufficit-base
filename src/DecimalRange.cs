using System.Text.Json.Serialization;
using static Sufficit.Constants;

namespace Sufficit
{
    /// <summary>
    /// Type alias for decimal numeric ranges
    /// </summary>
    public class DecimalRange : NumericRange<decimal>
    {
        public DecimalRange() : base() { }
        public DecimalRange(decimal? start, decimal? end, RangeInclusive inclusive = RangeInclusive.BOTH) : base(start, end, inclusive) { }
        public DecimalRange(decimal exact) : base(exact) { }
    }
}