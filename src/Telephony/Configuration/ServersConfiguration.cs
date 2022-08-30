using System;
using System.Collections.Generic;
using System.Text;

namespace Sufficit.Telephony.Configuration
{
    public class ServersConfiguration
    {
        public const string SECTIONNAME = "Sufficit:Telephony:Servers";

        public ServerOptions? FreePBXWeb { get; set; }

        public override bool Equals(object? other) =>
          other != null && other is ServersConfiguration p && p.FreePBXWeb == FreePBXWeb;

        public override int GetHashCode() => FreePBXWeb?.GetHashCode() ?? base.GetHashCode();
    }
}
