using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Sufficit.Telephony.FreePBX.FreePBXMailBoxStatusExtensions;

namespace Sufficit.Telephony.FreePBX
{
    public class FreePBXMailBox : FreePBXExtensionDestination, IFriendly
    {
        public const string FREEPBXPREFIX = "ext-local,vm";
        public const string FRIENDLYNAME = "FreePBX MailBox";

        #region IMPLEMENT INTERFACE IFRIENDLY

        string IFriendly.ToFriendly() => FRIENDLYNAME;

        #endregion

        /// <param name="asteriskExten">vmb*,vmu*,vms*,vmi*</param>
        public FreePBXMailBox (string asteriskExten)
        {
            Extension = asteriskExten.Substring(3);

            var prefix = asteriskExten.Substring(0, 3);
            Status = GetStatusFromPrefix(prefix);
        }

        public override string TypeName => typeof(FreePBXMailBox).Name;

        /// <summary>
        /// MailBox Variant
        /// </summary>
        public FreePBXMailBoxStatus Status { get; set; }

        public override string Asterisk => $"{FreePBXExtLocal.FREEPBXCONTEXT},{Status.GetPrefix()}{Extension},1";
    }
}
