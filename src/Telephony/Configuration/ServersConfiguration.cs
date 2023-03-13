using System;
using System.Collections.Generic;
using System.Text;

namespace Sufficit.Telephony.Configuration
{
    public class ServersConfiguration
    {
        /// <summary>
        /// Title of default configuration section (appsettings.json)
        /// </summary>
        public const string SECTIONNAME = "Sufficit:Telephony:Servers";

        public ServerOptions? FreePBXWeb { get; set; }

        public override bool Equals(object? other) =>
            other is ServersConfiguration p && 
            (p.FreePBXWeb?.Equals(FreePBXWeb) ?? p.FreePBXWeb == FreePBXWeb);

        public override int GetHashCode() => FreePBXWeb?.GetHashCode() ?? SECTIONNAME.GetHashCode();
    }
}
