using Sufficit.Notification;
using Sufficit.Telephony.Messages;
using System;

namespace Sufficit.Telephony
{
    public class FairUsagePolicyBoardNotification : BoardNotification
    {
        public const string UniqueID = FairUsagePolicyMessage.MODEL_ID;

        public const string MessageInvariant = "fair usage policy";

        public FairUsagePolicyBoardNotification(Guid contextid) 
        {
            base.ModelId = Guid.Parse(UniqueID);
            base.Message = MessageInvariant;

            ContextId = contextid;
        }

        // removing set acessor
        public override Guid ModelId => base.ModelId;

        public override string Message => base.Message;
    }
}
