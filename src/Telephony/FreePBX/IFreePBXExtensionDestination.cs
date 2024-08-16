using System;
using System.Collections.Generic;
using System.Text;

namespace Sufficit.Telephony.FreePBX
{
    public abstract class FreePBXExtensionDestination : Destination, IUserId
    {
        public string Extension { get; set; } = default!;

        public Guid? UserId { get; set; }
    }
}
