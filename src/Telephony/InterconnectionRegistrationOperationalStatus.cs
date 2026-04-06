using System;

namespace Sufficit.Telephony
{
    /// <summary>
    ///     Live operational status of one canonical interconnection registration as
    ///     observed from the local Asterisk runtime.
    /// </summary>
    public class InterconnectionRegistrationOperationalStatus
    {
        public Guid InterconnectionId { get; set; }

        public Guid RegistrationId { get; set; }

        public string Title { get; set; } = string.Empty;

        /// <summary>
        ///     Technical runtime identifier exposed to Asterisk, never the user-facing title.
        /// </summary>
        public string RuntimeId { get; set; } = string.Empty;

        public string? Node { get; set; }

        public bool Enabled { get; set; }

        /// <summary>
        ///     True when the runtime returned a line for this registration in
        ///     <c>pjsip show registrations</c>.
        /// </summary>
        public bool Observed { get; set; }

        public string State { get; set; } = "unknown";

        public string? Details { get; set; }

        public string? ServerUri { get; set; }

        public string? ClientUri { get; set; }
    }
}
