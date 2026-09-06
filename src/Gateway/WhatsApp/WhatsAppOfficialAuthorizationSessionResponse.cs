using System;
using System.Collections.Generic;

namespace Sufficit.Gateway.WhatsApp
{
    /// <summary>
    /// Current state of the short-lived Meta authorization a user granted, kept server-side
    /// (keyed by user + context) so the wizard can be re-entered — and more numbers configured —
    /// without repeating the OAuth login for each one. Deliberately never carries the Meta
    /// access token itself: only an opaque key the backend resolves back to the token.
    /// </summary>
    public class WhatsAppOfficialAuthorizationSessionResponse
    {
        /// <summary>
        /// True when a non-expired authorization session exists for this user + context.
        /// </summary>
        public bool Active { get; set; }

        public Guid ContextId { get; set; }

        /// <summary>
        /// Opaque handle of the active session, when <see cref="Active"/> is true. Safe to keep
        /// in the page state: it only works for the same user, same context, and only while the
        /// session has not expired.
        /// </summary>
        public string? SessionKey { get; set; }

        /// <summary>
        /// When the session expires (UTC) — the badge shows the remaining minutes from this.
        /// </summary>
        public DateTime? ExpiresAtUtc { get; set; }

        /// <summary>
        /// The phone numbers the granted authorization can see, so returning to the page
        /// restores the "choose a number" step without a new Meta login.
        /// </summary>
        public List<WhatsAppOfficialPhoneNumberSummary> Numbers { get; set; } = new();
    }
}
