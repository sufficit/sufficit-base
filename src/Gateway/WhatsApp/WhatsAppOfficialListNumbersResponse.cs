using System;
using System.Collections.Generic;

namespace Sufficit.Gateway.WhatsApp
{
    public class WhatsAppOfficialListNumbersResponse
    {
        /// <summary>
        /// False when Meta itself rejects the token (expired, malformed, revoked) — checked
        /// before searching for numbers, since "0 numbers found" looks identical to a client
        /// whether the token is fine-but-unassigned or outright invalid, and the fix is different
        /// for each (retype vs. regenerate).
        /// </summary>
        public bool TokenValid { get; set; }

        public string? TokenErrorMessage { get; set; }

        /// <summary>
        /// Handle opaco da sessão de autorização criada (ou renovada) no servidor com o token
        /// informado — válido por poucos minutos, por usuário e contexto. Permite configurar
        /// vários números com um único token colado, sem repetir a operação para cada um.
        /// </summary>
        public string? SessionKey { get; set; }

        /// <summary>
        /// Momento (UTC) em que essa sessão de autorização expira no servidor.
        /// </summary>
        public DateTime? ExpiresAtUtc { get; set; }

        /// <summary>
        /// System User tokens need <c>business_management</c> alongside
        /// <c>whatsapp_business_management</c> for their assigned assets to actually list —
        /// without it, <see cref="Numbers"/> can come back empty even for a token that genuinely
        /// has access (confirmed: it can still directly enable a known Phone Number ID).
        /// </summary>
        public bool HasBusinessManagementScope { get; set; }

        public List<WhatsAppOfficialPhoneNumberSummary> Numbers { get; set; } = new();
    }
}
