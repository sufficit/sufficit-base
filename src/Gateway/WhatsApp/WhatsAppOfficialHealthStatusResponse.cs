using System;
using System.Collections.Generic;

namespace Sufficit.Gateway.WhatsApp
{
    /// <summary>
    /// Diagnóstico somente leitura do health_status que a Meta associa ao número, WABA,
    /// negócio e aplicativo. Não contém access token nem conteúdo de chamadas/mensagens.
    /// </summary>
    public sealed class WhatsAppOfficialHealthStatusResponse
    {
        public bool Success { get; set; }

        public string PhoneNumberId { get; set; } = string.Empty;

        public string? DisplayPhoneNumber { get; set; }

        public string? CanSendMessage { get; set; }

        public string? PhoneCanReceiveCallSip { get; set; }

        public string? AppCanReceiveCallSip { get; set; }

        public string? AppCanSendMessage { get; set; }

        public string? BusinessCanSendMessage { get; set; }

        public string? WabaId { get; set; }

        public string? BusinessId { get; set; }

        public string? AppId { get; set; }

        public DateTime CheckedAtUtc { get; set; }

        public List<WhatsAppOfficialHealthIssue> Issues { get; set; } = new();

        public string? ErrorMessage { get; set; }
    }

    public sealed class WhatsAppOfficialHealthIssue
    {
        public string EntityType { get; set; } = string.Empty;

        public string? EntityId { get; set; }

        public int? ErrorCode { get; set; }

        public string Description { get; set; } = string.Empty;

        public string? PossibleSolution { get; set; }
    }
}
