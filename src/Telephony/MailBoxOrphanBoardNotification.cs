using Sufficit.Notification;
using Sufficit.Telephony.Messages;
using System;

namespace Sufficit.Telephony
{
    public class MailBoxOrphanBoardNotification : BoardNotification
    {
        public const string UniqueID = OrphanMailBoxMessage.MODEL_ID;

        public const string MessageInvariant = "orphan voice mail";

        public MailBoxOrphanBoardNotification() 
        {
            base.ModelId = Guid.Parse(UniqueID);
            base.Message = MessageInvariant; 
        }

        // removing set acessor
        public override Guid ModelId => base.ModelId;

        public override string Message => base.Message;
    }
}
