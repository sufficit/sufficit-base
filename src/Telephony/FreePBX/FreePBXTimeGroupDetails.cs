using System;
using System.Collections.Generic;
using System.Text;

namespace Sufficit.Telephony.FreePBX
{
    public class FreePBXTimeGroupDetails
    {
        public uint Id {  get; set; }

        public uint TimeGroupId { get; set; }

        public string TimeInterval { get; set; } = default!;

        public override bool Equals(object? obj)
            => obj is FreePBXTimeGroupDetails other &&
            other.Id == Id &&
            other.TimeGroupId == TimeGroupId &&
            other.TimeInterval == TimeInterval;

        public override int GetHashCode()
            => (Id, TimeGroupId, TimeInterval).GetHashCode();
    }
}
