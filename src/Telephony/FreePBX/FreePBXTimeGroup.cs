using System;
using System.Collections.Generic;
using System.Text;

namespace Sufficit.Telephony.FreePBX
{
    public class FreePBXTimeGroup
    {
        public uint Id {  get; set; }

        public HashSet<TimeInterval> Intervals { get; set; } = new HashSet<TimeInterval>();

        public override bool Equals(object? obj)
            => obj is FreePBXTimeGroup other &&
            other.Id == Id &&
            other.Intervals.SetEquals(Intervals);

        public override int GetHashCode()
            => (Id, Intervals).GetHashCode();
    }
}