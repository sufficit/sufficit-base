using System;
using System.Collections.Generic;
using System.Text;

namespace Sufficit.Telephony.FreePBX
{
    /// <summary>
    /// (FreePBX) Direct Calls to extensions <br />
    /// Dial to exten, do not checks for avail, multiple channels simultaneous
    /// </summary>
    public class FreePBXDirectCall : FreePBXExtensionDestination, IFriendly
    {
        public const string FREEPBXCONTEXTOLD = "sufficit-directcall";
        public const string FREEPBXCONTEXT = "sufficit-freepbx-app-directcall";
        public const string FRIENDLYNAME = "FreePBX Direct Call";

        #region IMPLEMENT INTERFACE IFRIENDLY

        string IFriendly.ToFriendly() => FRIENDLYNAME;

        #endregion

        public override string TypeName => typeof(FreePBXDirectCall).Name;

        public override string Asterisk => $"{FREEPBXCONTEXT},{Extension},1";

        public override string? Title => Extension;

        public override bool Equals(object? obj)
            => obj is FreePBXDIDDirect other &&
            other.Extension == Extension &&
            other.UserId == UserId &&
            base.Equals(other);

        public override int GetHashCode()
            => (Extension, UserId, base.GetHashCode()).GetHashCode();
    }
}
