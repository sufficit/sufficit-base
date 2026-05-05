using System.Collections.Generic;

namespace Sufficit.Telephony.CallForward
{
    /// <summary>
    /// Result of an AMI probe verifying a call-forward rule exists in the Asterisk dialplan.
    /// </summary>
    /// <remarks>
    /// <para><strong>Scope:</strong> Shared between <c>sufficit-endpoints</c> API and <c>sufficit-client</c>.</para>
    /// <para><strong>Usage Pattern:</strong> Returned by <c>GET /telephony/callforward/asteriskprobe</c>.
    /// Connects to the Asterisk Manager Interface, runs <c>dialplan show &lt;guid&gt;@sufficit-app-forward</c>
    /// and inspects the output to confirm the extension is present in the dialplan.</para>
    /// </remarks>
    public class CallForwardAsteriskProbeResult
    {
        /// <summary>Call-forward rule identifier that was probed.</summary>
        public System.Guid Id { get; set; }

        /// <summary>Whether the AMI connection succeeded.</summary>
        public bool Connected { get; set; }

        /// <summary>Whether the extension for this rule was found in the dialplan context.</summary>
        public bool ExtensionFound { get; set; }

        /// <summary>Raw output lines from the <c>dialplan show</c> command, trimmed.</summary>
        public List<string> Output { get; set; } = new List<string>();

        /// <summary>Human-readable notes about each probe step.</summary>
        public List<string> Notes { get; set; } = new List<string>();

        /// <summary>Overall probe success: connected and extension found.</summary>
        public bool IsHealthy => Connected && ExtensionFound;
    }
}
