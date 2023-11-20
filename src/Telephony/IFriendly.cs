using System;
using System.Collections.Generic;
using System.Text;

namespace Sufficit.Telephony
{
    /// <summary>
    ///     Used by classes that have a friendly user description or explanation
    /// </summary>
    public interface IFriendly
    {
        string ToFriendly();
    }
}
