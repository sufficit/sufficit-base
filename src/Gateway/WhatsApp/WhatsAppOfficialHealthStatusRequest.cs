using System;

namespace Sufficit.Gateway.WhatsApp
{
    /// <summary>Identifica o número a ser consultado usando a autorização temporária server-side.</summary>
    public sealed class WhatsAppOfficialHealthStatusRequest
    {
        public Guid ContextId { get; set; }

        public string PhoneNumberId { get; set; } = string.Empty;

        /// <summary>Chave opaca; o token Meta correspondente nunca é enviado ao cliente.</summary>
        public string AuthorizationSessionKey { get; set; } = string.Empty;
    }
}
