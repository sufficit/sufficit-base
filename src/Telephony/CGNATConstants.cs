using System.Collections.Generic;

namespace Sufficit.Telephony
{
    /// <summary>
    ///     Constants related to CGNAT configuration for endpoints.
    /// </summary>
    /// <remarks>
    /// <para><strong>Scope:</strong> Shared model-level constants used by Blazor UI and FreePBX provider.</para>
    /// <para>Full CGNAT helper with settings and generation logic lives in sufficit-standard.</para>
    /// </remarks>
    public static class CGNATConstants
    {
        /// <summary>
        ///     EndPoint property key used to store the CGNAT flag (value: "true" / "false").
        /// </summary>
        public const string PropertyKey = "cgnat";

        /// <summary>
        ///     SIP settings for endpoints behind CGNAT (keyword → data).
        /// </summary>
        public static IReadOnlyDictionary<string, string> Settings { get; } = new Dictionary<string, string>
        {
            ["nat"] = "force_rport,comedia",
            ["directmedia"] = "no",
            ["qualify"] = "yes",
            ["qualifyfreq"] = "25",
            ["rtpkeepalive"] = "20",
            ["minexpiry"] = "60",
            ["maxexpiry"] = "180"
        };

        /// <summary>
        ///     Flags value used for CGNAT SIP properties (priority/sequencing) in the FreePBX sip table.
        /// </summary>
        public const int Flags = 50;
    }
}
