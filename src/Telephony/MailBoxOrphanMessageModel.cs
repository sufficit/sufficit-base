﻿using Sufficit.Exchange;
using Sufficit.Telephony.Messages;
using System;
using System.Collections.Generic;
using System.Text;

namespace Sufficit.Telephony
{
    [Obsolete("2024/06/14 not used anymore")]
    public struct MailBoxOrphanMessageModel : IMessageModel
    {
        public const string UniqueID = OrphanMailBoxMessage.MODEL_ID;

        public readonly Guid Id => Guid.Parse(UniqueID);

        public readonly string Name => "MailBox Without valid contact";
    }
}
