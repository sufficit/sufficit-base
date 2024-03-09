using Sufficit.Exchange;
using Sufficit.Notification;
using System;
using System.Collections.Generic;
using System.Text;
using System.Xml;

namespace Sufficit.Telephony
{
    public class MailBoxOrphanBoardNotification : BoardNotification
    {
        public MailBoxOrphanBoardNotification() 
        {
            base.ModelId = Guid.Parse(UniqueID);
            base.Message = MessageInvariant; 
        }

        public const string UniqueID = MailBoxOrphanMessageModel.UniqueID;

        public const string MessageInvariant = "orphan voice mail";
        public override Guid ModelId => base.ModelId;
        public override string Message => base.Message;
    }
}
