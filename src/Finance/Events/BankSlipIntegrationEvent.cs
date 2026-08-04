using System;
using System.Text.Json.Serialization;
using Sufficit.Events;

namespace Sufficit.Finance.Events
{
    /// <summary>
    /// Stable event names emitted by the bank-slip aggregate.
    /// </summary>
    public static class BankSlipIntegrationEventTypes
    {
        public const string Requested = "bankslip.requested";
        public const string Ready = "bankslip.ready";
        public const string Paid = "bankslip.paid";
        public const string Canceled = "bankslip.canceled";
        public const string ProviderStatusChanged = "bankslip.provider_status.changed";
        public const string PaymentReconciliationRequired = "bankslip.payment.reconciliation_required";

        public static bool IsFinancial(string eventType)
            => string.Equals(eventType, Requested, StringComparison.Ordinal)
            || string.Equals(eventType, Ready, StringComparison.Ordinal)
            || string.Equals(eventType, Paid, StringComparison.Ordinal)
            || string.Equals(eventType, Canceled, StringComparison.Ordinal)
            || string.Equals(eventType, ProviderStatusChanged, StringComparison.Ordinal)
            || string.Equals(eventType, PaymentReconciliationRequired, StringComparison.Ordinal);
    }

    /// <summary>
    /// Stable consumer identities used by integration receipts and audits.
    /// </summary>
    public static class BankSlipIntegrationConsumers
    {
        public const string FinanceProjection = "bankslip-finance-v1";
    }

    /// <summary>
    /// Provider-independent, versioned representation of a bank-slip lifecycle event.
    /// Contains only the data needed by internal consumers and intentionally excludes
    /// payer PII, credentials, provider payloads, barcodes and document URLs.
    /// </summary>
    public sealed class BankSlipIntegrationEvent : IEvent, IContextId
    {
        public const int CurrentSchemaVersion = 1;

        [JsonPropertyName("event_id")]
        public Guid Id { get; set; }

        [JsonPropertyName("event_type")]
        public string Type { get; set; } = string.Empty;

        [JsonPropertyName("schema_version")]
        public int SchemaVersion { get; set; } = CurrentSchemaVersion;

        [JsonPropertyName("occurred_at_utc")]
        public DateTime Timestamp { get; set; }

        [JsonPropertyName("tenant_id")]
        public Guid TenantId { get; set; }

        [JsonPropertyName("bank_slip_id")]
        public Guid BankSlipId { get; set; }

        [JsonPropertyName("context_id")]
        public Guid ContextId { get; set; }

        [JsonPropertyName("aggregate_version")]
        public long AggregateVersion { get; set; }

        [JsonPropertyName("status")]
        [JsonConverter(typeof(JsonStringEnumConverter))]
        public BankSlipStatus Status { get; set; }

        [JsonPropertyName("face_value")]
        public decimal FaceValue { get; set; }

        [JsonPropertyName("settled_value")]
        public decimal? SettledValue { get; set; }

        [JsonPropertyName("currency")]
        public string Currency { get; set; } = "BRL";

        [JsonPropertyName("issuance_cost")]
        public decimal IssuanceCost { get; set; }

        [JsonPropertyName("expiration")]
        public DateTime Expiration { get; set; }

        [JsonPropertyName("paid_at_utc")]
        public DateTime? PaidAtUtc { get; set; }

        [JsonPropertyName("canceled_at_utc")]
        public DateTime? CanceledAtUtc { get; set; }

        [JsonPropertyName("provider")]
        public string Provider { get; set; } = string.Empty;

        [JsonPropertyName("provider_environment")]
        [JsonConverter(typeof(JsonStringEnumConverter))]
        public BankSlipProviderEnvironment ProviderEnvironment { get; set; }

        [JsonPropertyName("provider_charge_id")]
        public string? ProviderChargeId { get; set; }

        [JsonPropertyName("provider_status")]
        public string? ProviderStatus { get; set; }

        [JsonPropertyName("financial_document")]
        public string FinancialDocument { get; set; } = string.Empty;

        [JsonPropertyName("source")]
        public string Source { get; set; } = string.Empty;

        [JsonPropertyName("causation_id")]
        public Guid? CausationId { get; set; }

        [JsonPropertyName("correlation_id")]
        public Guid? CorrelationId { get; set; }

        [JsonPropertyName("requested_by")]
        public Guid? RequestedBy { get; set; }
    }
}
