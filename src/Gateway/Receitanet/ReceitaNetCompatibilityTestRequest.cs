using System;
namespace Sufficit.Gateway.ReceitaNet
{
    /// <summary>
    /// Request payload used to validate ReceitaNet compatibility for a selected token.
    /// </summary>
    public class ReceitaNetCompatibilityTestRequest
    {
        /// <summary>
        /// Optional saved gateway identifier used to resolve persisted tokens when the request does not send one directly.
        /// </summary>
        public Guid? GatewayId { get; set; }

        /// <summary>
        /// Optional list of tokens currently present in the UI when the gateway has not been saved yet.
        /// </summary>
        public string[] Tokens { get; set; } = Array.Empty<string>();

        /// <summary>
        /// Explicit token selected by the user for the test.
        /// </summary>
        public string? Token { get; set; }

        /// <summary>
        /// Operation selected for an individual compatibility test.
        /// </summary>
        public ReceitaNetCompatibilityOperation Operation { get; set; }

        /// <summary>
        /// Optional client CPF/CNPJ used for contract lookup tests.
        /// </summary>
        public string? Document { get; set; }

        /// <summary>
        /// Optional contact phone used for phone lookup and contract-bound requests.
        /// </summary>
        public string? Phone { get; set; }

        /// <summary>
        /// Optional explicit contract identifier used when the lookup should be skipped.
        /// </summary>
        public int? ContractId { get; set; }

        /// <summary>
        /// Optional delivery channel used by charge notification tests.
        /// The value is parsed by the API using the ReceitaNet enum names.
        /// </summary>
        public string? NotificationChannel { get; set; }

        /// <summary>
        /// Optional ticket type used by ticket creation tests.
        /// The value is parsed by the API using the ReceitaNet enum names.
        /// </summary>
        public string? TicketKind { get; set; }

        /// <summary>
        /// Optional reason used by ticket creation tests.
        /// </summary>
        public string? TicketReason { get; set; }

        /// <summary>
        /// Optional explicit ticket identifier used by recording update tests.
        /// </summary>
        public int? TicketId { get; set; }

        /// <summary>
        /// Optional recording URL used by recording update tests.
        /// </summary>
        public string? RecordingUrl { get; set; }

        /// <summary>
        /// Optional extension value forwarded to the recording update endpoint.
        /// </summary>
        public int? RecordingExtension { get; set; }

        /// <summary>
        /// Optional flag indicating whether the recording update should finalize the ticket.
        /// </summary>
        public bool? RecordingFinalize { get; set; }

        /// <summary>
        /// Enables tests that may create or mutate data in the external ReceitaNet system.
        /// </summary>
        public bool AllowSideEffects { get; set; }
    }
}