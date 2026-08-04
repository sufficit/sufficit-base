using System;
using System.Text.Json;

namespace Sufficit.Finance
{
    /// <summary>
    /// Represents the sanitized result returned to an authorized operator.
    /// </summary>
    public sealed class BankSlipProviderDiagnosticResult
    {
        public string Provider { get; set; } = string.Empty;

        public BankSlipProviderEnvironment Environment { get; set; }

        public BankSlipProviderDiagnosticOperation Operation { get; set; }

        public DateTime ExecutedAtUtc { get; set; }

        public double DurationMilliseconds { get; set; }

        public int HttpStatusCode { get; set; }

        public string Outcome { get; set; } = string.Empty;

        public string? ErrorCode { get; set; }

        public Guid CorrelationId { get; set; }

        public JsonElement Payload { get; set; }
    }
}
