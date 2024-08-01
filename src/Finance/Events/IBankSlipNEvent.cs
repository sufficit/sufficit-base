using System;
using System.Collections.Generic;
using System.Text;

namespace Sufficit.Finance
{
    public interface IBankSlipNEvent : Sufficit.Notification.IEvent
    {
        public BankSlip BankSlip { get; set; }
    }
}
