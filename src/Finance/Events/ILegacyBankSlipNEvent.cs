using System;
using System.Collections.Generic;
using System.Text;

namespace Sufficit.Finance
{
    public interface ILegacyBankSlipNEvent : Sufficit.Notification.INotificationEvent
    {
        public LegacyBankSlip LegacyBankSlip { get; set; }
    }
}
