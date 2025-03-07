using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sufficit.Telephony.Asterisk.Manager
{
    public class AMIHubOptions
    {
        public const string SECTIONNAME = "Sufficit:Telephony:AMIHub";

        public const string RegistryStatusHubPattern = "/RegistryStatusHub";

        public const string AMIHubPattern = "/AMIHub";

#if DEBUG
        public string BaseAddress { get; set; } = "https://localhost:26507";
#else
        public string BaseAddress { get; set; } = "https://eveo-apps.sufficit.com.br:26507";
#endif

        public override bool Equals(object? obj)
            => obj is AMIHubOptions p && p.BaseAddress == BaseAddress ;

        public override int GetHashCode()
            => (BaseAddress).GetHashCode();
    }
}
