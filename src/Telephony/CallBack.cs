using System;
using System.Collections.Generic;
using System.Text;

namespace Sufficit.Telephony
{
    /// <summary>
    /// Old Custom Application CallBack
    /// </summary>
    public class CallBack : IDestination
    {
        public const string FREEPBXCONTEXT = "app-sufficit-callback";
        public const string FRIENDLYNAME = "CallBack";

        public Guid ContextId { get; set; }

        public string Asterisk { get; set; } = default!;

        public Guid? Id => throw new NotImplementedException();

        public string TypeName => throw new NotImplementedException();

        public string? Title => throw new NotImplementedException();

        public string? Description => throw new NotImplementedException();

        Guid? IDestination.ContextId => throw new NotImplementedException();
    }
}
