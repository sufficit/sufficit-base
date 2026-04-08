using Sufficit.Telephony.InterConnection.PJSIP;
using System.Collections.Generic;

namespace Sufficit.Telephony.InterConnection
{
    /// <summary>
    ///     Preview payload describing the realtime objects generated for one interconnection.
    /// </summary>
    public class InterconnectionProvisioningPreview
    {
        public Interconnection Interconnection { get; set; } = new Interconnection();

        public string ObjectPrefix { get; set; } = string.Empty;

        public ICollection<string> Notes { get; set; } = new List<string>();

        public ICollection<PJSIPEndPoint> EndPoints { get; set; } = new List<PJSIPEndPoint>();

        public ICollection<PJSIPAOR> Aors { get; set; } = new List<PJSIPAOR>();

        public ICollection<PJSIPAuth> Auths { get; set; } = new List<PJSIPAuth>();

        public ICollection<PJSIPEndPointIdentify> Identifies { get; set; } = new List<PJSIPEndPointIdentify>();
    }
}
