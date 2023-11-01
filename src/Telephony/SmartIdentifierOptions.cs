using System;
using System.Collections.Generic;
using System.Text;

namespace Sufficit.Telephony
{
    public class SmartIdentifierOptions : Dictionary<string, string>
    {
        /// <summary>
        /// Used to configure options
        /// </summary>
        public const string SECTIONNAME = nameof(Sufficit) + ":" + nameof(Telephony) + ":SmartIdentifier";
    }
}
