using System;
using System.Collections.Generic;

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
        /// Handle opaco da autorização guardada no servidor (válida por poucos minutos, por
        /// usuário e contexto). Presente no fluxo de descoberta no lugar do
        /// <see cref="AccessToken"/>: o token fica no backend e a tela usa esta chave para
        /// habilitar números e trocar de conta sem repetir o login da Meta.
        /// </summary>
        public string? SessionKey { get; set; }

        /// <summary>
        /// Momento (UTC) em que a autorização guardada no servidor expira.
        /// </summary>
        public DateTime? ExpiresAtUtc { get; set; }

        /// <summary>
        /// ID da aplicação Meta
        /// </summary>
        public string AppId { get; set; } = string.Empty;

        /// <summary>
        /// Números que a autorização do Embedded Signup permite consultar. No fluxo de
        /// descoberta, essa lista é retornada sem registrar o número, assinar webhooks ou
        /// alterar Calling/SIP.
        /// </summary>
        public List<WhatsAppOfficialPhoneNumberSummary> Numbers { get; set; } = new();

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
