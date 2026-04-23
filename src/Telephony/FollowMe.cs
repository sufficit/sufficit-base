using System;

namespace Sufficit.Telephony
{
    [Obsolete("Generic siga-me (FollowMe) is not used in this system. Use CallForwardApplication (sufficit-app-forward) for standalone proactive call forwarding.")]
    public class FollowMe
    {
        public Guid ExtensionId { get; set; }

        public int Cause { get; set; }

        public string Dialing { get; set; } = string.Empty;

        public bool Masked { get; set; }
    }
}
