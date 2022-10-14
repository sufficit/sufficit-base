using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sufficit.Telephony
{
    public class CallRecordingOptions
    {
        /// <summary>
        /// Used to configure options
        /// </summary>
        public const string SECTIONNAME = nameof(Sufficit) + ":" + nameof(Telephony) + ":CallRecording";

        /// <summary>
        /// List of SSH Call Recording Providers Individual Options
        /// </summary>
        public HashSet<RemoteServerOptions>? SSHProviders { get; set; }
    }
}
