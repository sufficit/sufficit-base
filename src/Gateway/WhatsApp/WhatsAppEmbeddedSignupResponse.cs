namespace Sufficit.Gateway.WhatsApp
{
    /// <summary>
    /// Resposta do processo de Meta Embedded Signup
    /// </summary>
    public class WhatsAppEmbeddedSignupResponse
    {
        /// <summary>
        /// Token de acesso do Meta
        /// </summary>
        public string AccessToken { get; set; } = string.Empty;

        /// <summary>
        /// ID da aplicação Meta
        /// </summary>
        public string AppId { get; set; } = string.Empty;

        /// <summary>
        /// Phone Number ID configurado
        /// </summary>
        public string PhoneNumberId { get; set; } = string.Empty;

        /// <summary>
        /// Número E.164 configurado
        /// </summary>
        public string Phone { get; set; } = string.Empty;

        /// <summary>
        /// Nome verificado do negócio
        /// </summary>
        public string? VerifiedName { get; set; }

        /// <summary>
        /// Nome de exibição do WhatsApp
        /// </summary>
        public string? DisplayPhoneNumber { get; set; }

        /// <summary>
        /// SIP hostname configurado
        /// </summary>
        public string SipHostname { get; set; } = string.Empty;

        /// <summary>
        /// SIP port configurado
        /// </summary>
        public int SipPort { get; set; }

        /// <summary>
        /// Indica se o processo foi bem-sucedido
        /// </summary>
        public bool Success { get; set; }

        /// <summary>
        /// Mensagem de erro, se houver
        /// </summary>
        public string? ErrorMessage { get; set; }
    }
}