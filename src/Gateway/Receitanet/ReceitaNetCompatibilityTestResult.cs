namespace Sufficit.Gateway.ReceitaNet
{
    /// <summary>
    /// Result for a single ReceitaNet compatibility operation.
    /// </summary>
    public class ReceitaNetCompatibilityTestResult
    {
        /// <summary>
        /// Operation that was executed or skipped.
        /// </summary>
        public ReceitaNetCompatibilityOperation Operation { get; set; }

        /// <summary>
        /// Token used for the request.
        /// </summary>
        public string Token { get; set; } = string.Empty;

        /// <summary>
        /// Indicates whether the ReceitaNet endpoint responded in a compatible way for this operation.
        /// </summary>
        public bool Compatible { get; set; }

        /// <summary>
        /// Optional operation-level result when the endpoint exposes an additional business status.
        /// </summary>
        public bool? OperationSucceeded { get; set; }

        /// <summary>
        /// Indicates that the operation was intentionally skipped.
        /// </summary>
        public bool Skipped { get; set; }

        /// <summary>
        /// Human-readable message describing the outcome.
        /// </summary>
        public string Message { get; set; } = string.Empty;

        /// <summary>
        /// Optional textual outcome extracted from the external API response.
        /// </summary>
        public string? Outcome { get; set; }

        /// <summary>
        /// Contract identifier found or used during the test.
        /// </summary>
        public int? ContractId { get; set; }

        /// <summary>
        /// Contract title found during the test.
        /// </summary>
        public string? ContractTitle { get; set; }

        /// <summary>
        /// Optional protocol returned by ReceitaNet.
        /// </summary>
        public string? Protocol { get; set; }

        /// <summary>
        /// Optional ticket identifier returned or used during the test.
        /// </summary>
        public int? TicketId { get; set; }

        /// <summary>
        /// Raw serialized response or diagnostic payload for troubleshooting.
        /// </summary>
        public string? RawResponse { get; set; }
    }
}