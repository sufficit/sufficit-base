using System;
using System.Text.Json.Serialization;

namespace Sufficit.Gateway.WhatsApp
{
    /// <summary>
    /// Metadados públicos do aplicativo Meta usado pelo fluxo WhatsApp Official.
    /// A referência aponta para o segredo no Vault central; o segredo nunca é retornado.
    /// </summary>
    public sealed class WhatsAppOfficialAppConfiguration
    {
        public string AppKey { get; set; } = string.Empty;
        public string DisplayName { get; set; } = string.Empty;
        public string AppId { get; set; } = string.Empty;
        public string ConfigId { get; set; } = string.Empty;
        public string? BusinessLoginConfigId { get; set; }
        public string ApiVersion { get; set; } = "v22.0";
        public string SecretReference { get; set; } = string.Empty;

        /// <summary>Alias de compatibilidade em código legado; não é serializado.</summary>
        [JsonIgnore]
        public string SecretConfigurationKey
        {
            get => SecretReference;
            set => SecretReference = value;
        }
        public bool IsActive { get; set; }
        public bool HasConfiguredSecret { get; set; }
        public bool CanManage { get; set; }
        public DateTime UpdatedAtUtc { get; set; }
    }

    public sealed class WhatsAppOfficialAppUpsertRequest
    {
        public string AppKey { get; set; } = string.Empty;
        public string DisplayName { get; set; } = string.Empty;
        public string AppId { get; set; } = string.Empty;
        public string ConfigId { get; set; } = string.Empty;
        public string? BusinessLoginConfigId { get; set; }
        public string ApiVersion { get; set; } = "v22.0";
        public string SecretReference { get; set; } = string.Empty;

        /// <summary>Alias JSON legado aceito durante a transição do catálogo.</summary>
        [JsonPropertyName("secretConfigurationKey")]
        public string LegacySecretConfigurationKey
        {
            get => SecretReference;
            set
            {
                if (string.IsNullOrWhiteSpace(SecretReference))
                    SecretReference = value;
            }
        }

        /// <summary>
        /// Valor transitório de entrada. É enviado ao Vault e nunca persistido ou retornado.
        /// </summary>
        [JsonPropertyName("clientSecret")]
        public string? ClientSecret { get; set; }
    }

    public sealed class WhatsAppOfficialAppActivationRequest
    {
        public string AppKey { get; set; } = string.Empty;
    }
}
