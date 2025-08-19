using Sufficit.Exchange;
using System;
using System.Collections.Generic;
using System.Text;

namespace Sufficit.Telephony
{
    [Obsolete("2024/06/14 not used anymore")]
    public struct CurrentBalanceINotificationEvent : IMessageModel
    {
        public const string UniqueID = "053e2c3c-c113-4015-b58e-d246ef65bd6d";

        public readonly Guid Id => Guid.Parse(UniqueID);

        public readonly string Name => "Current Calls Balance Internal Event";
    }
}
