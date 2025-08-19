using Sufficit.Exchange;
using System;
using System.Collections.Generic;
using System.Text;

namespace Sufficit.Telephony
{
    public struct ServiceRenewedINotificationEvent : IMessageModel
    {
        public const string UniqueID = "b3968224-760a-4a0a-93eb-8e7cde2d61c8";

        public readonly Guid Id => Guid.Parse(UniqueID);

        public readonly string Name => "Service Renewed Internal Event";
    }
}
