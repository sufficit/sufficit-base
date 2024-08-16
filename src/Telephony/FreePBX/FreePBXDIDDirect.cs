using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sufficit.Telephony.FreePBX
{
    /// <summary>
    /// (FreePBX) From DID Direct to Extension [from-did-direct] <br />
    /// Sends to ext-local, checks avail, 1 channel once
    /// </summary>
    /// <remarks>* Prefer use of FreePBXDirectCall</remarks>
    public class FreePBXDIDDirect : FreePBXExtensionDestination, IFriendly
    {
        public const string FREEPBXCONTEXT = "from-did-direct";
        public const string FRIENDLYNAME = "FreePBX DID Direct";

        #region IMPLEMENT INTERFACE IFRIENDLY

        string IFriendly.ToFriendly() => FRIENDLYNAME;

        #endregion

        public override string TypeName => typeof(FreePBXDIDDirect).Name;

        public override string Asterisk => $"{FREEPBXCONTEXT},{Extension},1";

        public override string? Title => Extension;

        public override bool Equals (object? obj)
            => obj is FreePBXDIDDirect other &&
            other.Extension == Extension &&
            other.UserId == UserId && 
            base.Equals(other);

        public override int GetHashCode()
            => (Extension, UserId, base.GetHashCode()).GetHashCode();
    }
}
