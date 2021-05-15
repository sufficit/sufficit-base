using System;
using System.Collections.Generic;
using System.Text;

namespace Sufficit.Notification.Events
{
    public class QueueAbandonNEvent : Event
    {
        #region IMPLEMENT EVENT

        public override Guid ID => Guid.Parse(IDEVENT);

        public override string Title => TITLE;

        #endregion

        public const string IDEVENT = "6571680f-7017-4f6c-98dc-23fce63bd731";
        public const string TITLE = "Abandono de fila de espera";
    }
}
