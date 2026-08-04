using System;
using System.Collections.Generic;
using System.Text.Json;
using System.Threading;
using System.Threading.Tasks;

namespace Sufficit.Gateway
{
    /// <summary>
    /// Classifies the operational impact of an allow-listed gateway operation.
    /// </summary>
    public enum GatewayDiagnosticRisk : byte
    {
        ReadOnly = 0,
        SandboxMutation = 1,
        ProductionMutation = 2,
        Sensitive = 3
    }

    /// <summary>
    /// Describes one provider operation exposed by the controlled gateway lab.
    /// URLs, methods and headers are owned by the gateway implementation and are
    /// never supplied by the browser.
    /// </summary>
    public sealed class GatewayDiagnosticOperation
    {
        public string Code { get; set; } = string.Empty;
        public string Category { get; set; } = string.Empty;
        public string Title { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public string Method { get; set; } = "GET";
        public GatewayDiagnosticRisk Risk { get; set; } = GatewayDiagnosticRisk.ReadOnly;
        public bool RequiresResourceId { get; set; }
        public bool RequiresSecondaryResourceId { get; set; }
        public bool RequiresPayload { get; set; }
        public bool Available { get; set; } = true;
        public string? AvailabilityNote { get; set; }
    }

    /// <summary>
    /// Returns the tenant-aware provider catalog without exposing credentials.
    /// </summary>
    public sealed class GatewayDiagnosticCatalog
    {
        public string Provider { get; set; } = string.Empty;
        public GatewayEnvironment Environment { get; set; }
        public bool Configured { get; set; }
        public IReadOnlyList<GatewayDiagnosticOperation> Operations { get; set; }
            = Array.Empty<GatewayDiagnosticOperation>();
    }

    /// <summary>
    /// Carries the bounded inputs accepted by an allow-listed provider operation.
    /// </summary>
    public sealed class GatewayDiagnosticRequest
    {
        public string Provider { get; set; } = string.Empty;
        public string OperationCode { get; set; } = string.Empty;
        public string? ResourceId { get; set; }
        public string? SecondaryResourceId { get; set; }
        public int Offset { get; set; }
        public int Limit { get; set; } = 20;
        public JsonElement? Payload { get; set; }
        public string? Confirmation { get; set; }
    }

    /// <summary>
    /// Carries an untrusted provider response to the runtime sanitization boundary.
    /// </summary>
    public sealed class GatewayDiagnosticProviderResult
    {
        public int HttpStatusCode { get; set; }
        public JsonElement Payload { get; set; }
    }

    /// <summary>
    /// Represents a sanitized and audited gateway lab execution.
    /// </summary>
    public sealed class GatewayDiagnosticResult
    {
        public string Provider { get; set; } = string.Empty;
        public GatewayEnvironment Environment { get; set; }
        public string OperationCode { get; set; } = string.Empty;
        public DateTime ExecutedAtUtc { get; set; }
        public double DurationMilliseconds { get; set; }
        public int HttpStatusCode { get; set; }
        public string Outcome { get; set; } = string.Empty;
        public string? ErrorCode { get; set; }
        public Guid CorrelationId { get; set; }
        public JsonElement Payload { get; set; }
    }

    /// <summary>
    /// Provider-owned gateway lab boundary.
    /// </summary>
    public interface IGatewayDiagnosticsGateway
    {
        string ProviderCode { get; }
        IReadOnlyList<GatewayDiagnosticOperation> DiagnosticOperations { get; }

        Task<GatewayDiagnosticProviderResult?> ExecuteDiagnosticAsync(
            GatewayDiagnosticRequest request,
            GatewayCallContext context,
            CancellationToken cancellationToken);
    }

    /// <summary>
    /// Resolves tenant-scoped gateway configuration without coupling the
    /// diagnostics runtime to a feature-specific persistence model.
    /// </summary>
    public interface IGatewayCallContextResolver
    {
        Task<GatewayCallContext?> ResolveAsync(
            Guid tenantId,
            string provider,
            CancellationToken cancellationToken);
    }

    /// <summary>
    /// Tenant-aware gateway lab application boundary.
    /// </summary>
    public interface IGatewayDiagnosticsService
    {
        Task<GatewayDiagnosticCatalog?> GetCatalogAsync(
            Guid tenantId,
            string provider,
            CancellationToken cancellationToken);

        Task<GatewayDiagnosticResult?> ExecuteAsync(
            Guid tenantId,
            Guid requestedBy,
            GatewayDiagnosticRequest request,
            CancellationToken cancellationToken);
    }
}
