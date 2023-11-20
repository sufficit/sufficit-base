using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sufficit.Telephony
{
    /// <summary>
    /// External dial direct to an internal extension
    /// </summary>
    public class DirectExtensionDialing : Destination, IDestination, IFriendly
    {
        public const string ASTERISKCONTEXT = "sufficit-directcall";
        public const string FRIENDLYNAME = "Discagem Direta";

        #region IMPLEMENT INTERFACE IFRIENDLY

        string IFriendly.ToFriendly() => FRIENDLYNAME;

        #endregion

        public DirectExtensionDialing(string extension)
        {
            Extension = extension;
        }

        public string Extension { get; }

        public override string TypeName => typeof(DirectExtensionDialing).Name;

        public override string Asterisk => $"{ASTERISKCONTEXT},{Extension},1";

        public override string? Title => Extension;

        public override string? Description => "Discagem direta a ramal";
    }
}
