using System.Text.Json.Serialization;
using static Sufficit.Constants;

namespace Sufficit
{
    /// <summary>
    /// Type alias for integer numeric ranges
    /// </summary>
    public class IntRange : NumericRange<int>
    {
        public IntRange() : base() { }
        public IntRange(int? start, int? end, RangeInclusive inclusive = RangeInclusive.BOTH) : base(start, end, inclusive) { }
        public IntRange(int exact) : base(exact) { }
    }
}