using System.Collections.Generic;
using Sufficit.Telephony.Asterisk.PJSIP;

namespace Sufficit.Telephony
{
    /// <summary>
    ///     Preview payload describing the realtime objects that would be generated for a customer telephony trunk.
    /// </summary>
    /// <remarks>
    ///     TODO: wire this preview to a real provisioning adapter once trunk synchronization is implemented.
    /// </remarks>
    public class CustomerTrunkProvisioningPreview
    {
        /// <summary>
        ///     Source trunk used to build the preview.
        /// </summary>
        public CustomerTrunk Trunk { get; set; } = new CustomerTrunk();

        /// <summary>
        ///     Human-readable caveats emitted while assembling the preview.
        /// </summary>
        public ICollection<string> Notes { get; set; } = new List<string>();

        /// <summary>
        ///     Candidate PJSIP endpoints that would be created.
        /// </summary>
        public ICollection<PJSIPEndPoint> EndPoints { get; set; } = new List<PJSIPEndPoint>();

        /// <summary>
        ///     Candidate PJSIP AOR entries that would be created.
        /// </summary>
        public ICollection<PJSIPAOR> Aors { get; set; } = new List<PJSIPAOR>();

        /// <summary>
        ///     Candidate PJSIP authentication entries that would be created.
        /// </summary>
        public ICollection<PJSIPAuth> Auths { get; set; } = new List<PJSIPAuth>();
    }
}
