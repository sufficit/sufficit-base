using System;
using System.Collections.Generic;
using System.Text;
using System.Text.Json.Serialization;

namespace Sufficit.Telephony.Asterisk
{
    public interface IAsterisk
    {
        /// <summary>
        /// Asterisk Goto representation
        /// </summary>
        string Asterisk { get; }
    }
}
