using System;
using System.Collections.Generic;
using System.Text;

namespace Sufficit.Telephony
{
    /// <summary>
    ///     Old Custom Application CallBack
    /// </summary>
    public class CallBack : Destination, IDestination, IFriendly
    {
        public const string FREEPBXCONTEXT = "app-sufficit-callback";
        public const string FRIENDLYNAME = "CallBack";

        #region IMPLEMENT INTERFACE IFRIENDLY

        string IFriendly.ToFriendly() => FRIENDLYNAME;

        #endregion
        #region IMPLEMENT INTERFACE IDESTINATION

        string IDestination.TypeName => nameof(CallBack);

        #endregion
        public override string Asterisk => $"{FREEPBXCONTEXT},s,1";

        public override string? Description => "Default CallBack Application";
    }
}
