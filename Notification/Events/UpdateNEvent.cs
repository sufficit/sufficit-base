﻿using System;
using System.Collections.Generic;
using System.Text;

namespace Sufficit.Notification.Events
{
    public class UpdateNEvent : Event
    {
        #region IMPLEMENT EVENT

        public override Guid ID => Guid.Parse(IDEVENT);

        public override string Title => TITLE;

        #endregion

        public const string IDEVENT = "3885d451-b507-464c-8904-9b6e7f726cb3";
        public const string TITLE = "Evento de atualização padrão";
    }
}
