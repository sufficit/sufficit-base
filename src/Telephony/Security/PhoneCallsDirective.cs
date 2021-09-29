using Sufficit.Security;
using System;
using System.Collections.Generic;
using System.Text;

namespace Sufficit.Telephony.Security
{
    public struct PhoneCallsDirective : IDirective
    {
        public const string Title = "phonecalls";
        string IDirective.Title => Title;

        public static string ToClaimType()
        {
            return $"allow_{Title}";
        }
    }
}
