using Sufficit.Exchange;
using System;
using System.Collections.Generic;
using System.Text;

namespace Sufficit.Identity
{
    public struct PasswordResetINotificationEvent : IMessageModel
    {
        public const string UniqueID = "90d294f0-5102-4bec-b988-14e1a385ce61";

        public readonly Guid Id => Guid.Parse(UniqueID);

        public readonly string Name => "Password Reset";
    }
}
