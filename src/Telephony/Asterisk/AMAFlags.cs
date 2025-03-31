using System;
using System.Collections.Generic;
using System.Text;

namespace Sufficit.Telephony.Asterisk
{
    /// <summary>
    ///     Automatic Message Accounting Flags <br />
    ///     Billing info or documentation only
    /// </summary>
    public enum AMAFlags
    {
        OMIT = 1,
        BILLING = 2,
        DOCUMENTATION = 3,
    }
}
