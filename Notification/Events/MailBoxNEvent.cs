using System;
using System.Collections.Generic;
using System.Text;

namespace Sufficit.Notification.Events
{
    public class MailBoxNEvent : Event
    {
        #region IMPLEMENT EVENT

        public override Guid ID => Guid.Parse(IDEVENT);

        public override string Title => TITLE;

        #endregion

        public const string IDEVENT = "69f367ab-c465-4f29-991f-b31b0b8e0760";
        public const string TITLE = "Caixa postal";  
    }
}
