using Sufficit.Exchange;
using System;
using System.Collections.Generic;
using System.Text;

namespace Sufficit.Telephony
{
    public struct MailBoxOrphanMessageModel : IMessageModel
    {
        public const string UniqueID = "20400267-b1bd-469b-90fd-eacdd607eb64";

        public readonly Guid Id => Guid.Parse(UniqueID);

        public readonly string Name => "MailBox Without valid contact";
    }
}
