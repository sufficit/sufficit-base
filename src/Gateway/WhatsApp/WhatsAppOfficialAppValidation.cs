using System;
using System.Collections.Generic;

namespace Sufficit.Gateway.WhatsApp
{
    /// <summary>
    /// Resultado da validação de um aplicativo Meta do catálogo do WhatsApp Official.
    /// Confere o segredo no Vault, se a Meta aceita as credenciais do aplicativo e se as
    /// permissões exigidas pelo fluxo estão aprovadas. Nunca carrega o segredo.
    /// </summary>
    public sealed class WhatsAppOfficialAppValidation
    {
        public string AppKey { get; set; } = string.Empty;
        public string AppId { get; set; } = string.Empty;

        /// <summary>Nome do aplicativo informado pela Meta, quando as credenciais são aceitas.</summary>
        public string? MetaAppName { get; set; }

        /// <summary>Indica se este é o aplicativo usado hoje pelos clientes finais.</summary>
        public bool IsActive { get; set; }

        /// <summary>Verdadeiro quando todas as verificações obrigatórias passaram.</summary>
        public bool IsValid { get; set; }

        public List<WhatsAppOfficialAppValidationCheck> Checks { get; set; } = new List<WhatsAppOfficialAppValidationCheck>();

        public DateTime CheckedAtUtc { get; set; }
    }

    public sealed class WhatsAppOfficialAppValidationCheck
    {
        public string Key { get; set; } = string.Empty;
        public string Label { get; set; } = string.Empty;
        public bool Passed { get; set; }

        /// <summary>Verificações opcionais não reprovam o aplicativo; apenas informam.</summary>
        public bool Required { get; set; } = true;

        public string? Detail { get; set; }
    }
}
