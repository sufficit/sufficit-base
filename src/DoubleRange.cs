using System.Text.Json.Serialization;
using static Sufficit.Constants;

namespace Sufficit
{
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