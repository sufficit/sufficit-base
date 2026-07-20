using System;

namespace Sufficit.Gateway.WhatsApp
{
    /// <summary>
    /// Request para Meta Embedded Signup - recebe o code do callback
    /// e troca por access_token, busca o primeiro phone_number_id
    /// e habilita Calling + SIP automaticamente
    /// </summary>
    public class WhatsAppEmbeddedSignupRequest
    {
        /// <summary>
        /// Required. The context requesting this number be pointed at Sufficit — used to check
        /// the number isn't already registered to a different context before touching Meta.
        /// </summary>
        public Guid ContextId { get; set; }

        /// <summary>
        /// Código de autorização recebido no callback do Meta Embedded Signup
        /// </summary>
        public string Code { get; set; } = string.Empty;

        /// <summary>
        /// WABA ID capturado do evento WA_EMBEDDED_SIGNUP/FINISH (postMessage), quando disponível.
        /// Evita ter que redescobrir a WABA via debug_token no backend.
        /// </summary>
        public string? WabaId { get; set; }

        /// <summary>
        /// Phone Number ID capturado do evento WA_EMBEDDED_SIGNUP/FINISH (postMessage), quando disponível.
        /// </summary>
        public string? PhoneNumberId { get; set; }
    }
}