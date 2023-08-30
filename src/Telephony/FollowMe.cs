using System;

namespace Sufficit.Telephony
{
    public class FollowMe
    {
        public Guid ExtensionId { get; set; }

        public int Cause { get; set; }

        public string Dialing { get; set; } = string.Empty;

        public bool Masked { get; set; }
    }
}
