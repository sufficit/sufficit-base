using System;
using System.Collections.Generic;
using System.Text;

namespace Sufficit.Telephony.FreePBX
{
    /// <summary>
    /// (FreePBX) ext-local extensions <br />
    /// Sends to ext-local, checks avail, 1 channel once
    /// </summary>
    /// <remarks>
    /// same as <see cref="FreePBXDIDDirect"/> <br />
    /// * Prefer use of FreePBXDirectCall
    /// </remarks>
    public class FreePBXExtLocal : FreePBXExtensionDestination, IFriendly
    {
        public const string FREEPBXCONTEXT = "ext-local";
        public const string FRIENDLYNAME = "FreePBX Ext Local";

        #region IMPLEMENT INTERFACE IFRIENDLY

        string IFriendly.ToFriendly() => FRIENDLYNAME;

        #endregion

        public override string TypeName => typeof(FreePBXExtLocal).Name;

        public override string Asterisk => $"{FREEPBXCONTEXT},{Extension},1";

        public override string? Title => Extension;

        public override bool Equals(object? obj)
            => obj is FreePBXExtLocal other &&
            other.Extension == Extension &&
            other.UserId == UserId &&
            base.Equals(other);

        public override int GetHashCode()
            => (Extension, UserId, base.GetHashCode()).GetHashCode();
    }
}
