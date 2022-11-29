using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Sufficit
{
    /// <summary>
    /// Default options for general remote servers
    /// </summary>
    public class RemoteServersOptions
    {
        /// <summary>
        /// Used to configure options
        /// </summary>
        public const string SECTIONNAME = nameof(Sufficit) + ":RemoteServers";

        /// <summary>
        /// List of SSH Gereric Providers Individual Options
        /// </summary>
        public HashSet<RemoteServer>? SSH { get; set; }
    }
}
