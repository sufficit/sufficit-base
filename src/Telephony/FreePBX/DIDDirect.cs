using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sufficit.Telephony.FreePBX
{
    /// <summary>
    /// (FreePBX) From DID Direct to Extension [from-did-direct]
    /// </summary>
    public class DIDDirect : Destination, IFriendly
    {
        public const string FREEPBXCONTEXT = "from-did-direct";
        public const string FRIENDLYNAME = "SIP Trunk";

        #region IMPLEMENT INTERFACE IFRIENDLY

        string IFriendly.ToFriendly() => FRIENDLYNAME;

        #endregion

        public DIDDirect(string extension)
        {
            Extension = extension;
        }

        public override string TypeName => typeof(DIDDirect).Name;

        public override string Asterisk => $"{FREEPBXCONTEXT},{Extension},1";

        public override string? Title => Extension;

        public string Extension { get; }
    }
}
