using System;

namespace Sufficit.Gateway.WhatsApp
{
    public class WhatsAppOfficialEnableRequest
    {
        /// <summary>
        /// Required. The context requesting this number be pointed at Sufficit — used to check
        /// the number isn't already registered to a different context before touching Meta.
        /// </summary>
        public Guid ContextId { get; set; }

        /// <summary>
        /// Optional. When empty, <see cref="PhoneNumber"/> is used to look up the id instead.
        /// </summary>
        public string? PhoneNumberId { get; set; }

        /// <summary>
        /// Optional. Used to resolve <see cref="PhoneNumberId"/> when the client doesn't know it
        /// (searched across every WABA our Meta token has access to).
        /// </summary>
        public string? PhoneNumber { get; set; }

        /// <summary>
        /// Optional. A short-lived access token the CLIENT generated themselves (e.g. via Meta's
        /// Graph API Explorer, or a temporary token from their own Business Settings) for their
        /// own WhatsApp Business Account — used instead of Sufficit's own Meta token/business id
        /// for this one call. For clients who already have another Tech Provider partner and
        /// can't add Sufficit as a second one (Meta only allows one), this lets them grant just
        /// enough one-time access to enable Calling+SIP without any lasting partnership. When
        /// omitted, falls back to Sufficit's own configured token, unchanged from before.
        /// </summary>
        public string? AccessToken { get; set; }
    }
}
