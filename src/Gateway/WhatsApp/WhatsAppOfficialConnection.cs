using System;

namespace Sufficit.Gateway.WhatsApp
{
    /// <summary>
    /// Metadados não sensíveis de uma conexão oficial do WhatsApp Cloud API.
    /// Pode ser compartilhado entre as camadas de domínio, API e persistência sem
    /// carregar a credencial usada para chamar a Graph API.
    /// </summary>
    public class WhatsAppOfficialConnection
    {
        /// <summary>
        /// Identificador do número de telefone na Meta.
        /// </summary>
        public string PhoneNumberId { get; set; } = string.Empty;

        /// <summary>
        /// Identificador do aplicativo no Meta Developers.
        /// </summary>
        public string AppId { get; set; } = string.Empty;

        /// <summary>
        /// Número de telefone normalizado para uso pela Sufficit.
        /// </summary>
        public string Phone { get; set; } = string.Empty;

        /// <summary>
        /// Número de telefone formatado para exibição.
        /// </summary>
        public string DisplayPhoneNumber { get; set; } = string.Empty;

        /// <summary>
        /// Nome verificado do número na Meta.
        /// </summary>
        public string? VerifiedName { get; set; }

        /// <summary>
        /// Nome verificado da conta WhatsApp Business.
        /// </summary>
        public string? WabaVerifiedName { get; set; }

        /// <summary>
        /// Identificador da conta WhatsApp Business.
        /// </summary>
        public string? WabaId { get; set; }

        /// <summary>
        /// Hostname do servidor SIP associado às chamadas.
        /// </summary>
        public string SipHostname { get; set; } = string.Empty;

        /// <summary>
        /// Porta do servidor SIP associado às chamadas.
        /// </summary>
        public int SipPort { get; set; }

        /// <summary>
        /// Indica se a conexão está habilitada.
        /// </summary>
        public bool IsActive { get; set; }

        /// <summary>
        /// Indica se a credencial associada à conexão expirou.
        /// </summary>
        public bool IsExpired { get; set; }

        /// <summary>
        /// Indica se a conexão foi criada pelo Embedded Signup.
        /// </summary>
        public bool IsEmbeddedSignup { get; set; }

        /// <summary>
        /// Data e hora de criação do registro.
        /// </summary>
        public DateTime CreatedAt { get; set; }

        /// <summary>
        /// Data e hora da última atualização do registro.
        /// </summary>
        public DateTime UpdatedAt { get; set; }

        /// <summary>
        /// Data e hora de expiração da credencial associada à conexão.
        /// </summary>
        public DateTime? ExpiresAt { get; set; }

        /// <summary>
        /// Identificador da rota Sufficit associada à conexão, quando houver.
        /// </summary>
        public string? RouteId { get; set; }
    }
}
