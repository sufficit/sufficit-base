namespace Sufficit.Gateway.WhatsApp
{
    /// <summary>
    /// Result of enabling Calling + SIP on a client's WhatsApp Official phone number.
    /// Returned so the client can register the routing destination in step 2 of the wizard.
    /// </summary>
    public class WhatsAppOfficialEnableResponse
    {
        /// <summary>
        /// Meta Cloud API phone_number_id that was enabled.
        /// </summary>
        public string PhoneNumberId { get; set; } = string.Empty;

        /// <summary>
        /// E.164 digits (no "+") of the enabled number, as returned by the Graph API.
        /// </summary>
        public string Phone { get; set; } = string.Empty;

        /// <summary>
        /// Meta's verified business name for this number, if any.
        /// </summary>
        public string? VerifiedName { get; set; }

        /// <summary>
        /// SIP hostname Meta was configured to send calls to.
        /// </summary>
        public string SipHostname { get; set; } = string.Empty;

        /// <summary>
        /// SIP port Meta was configured to send calls to.
        /// </summary>
        public int SipPort { get; set; }
    }
}
