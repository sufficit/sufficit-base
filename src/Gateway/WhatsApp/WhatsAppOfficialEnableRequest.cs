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
    }
}
