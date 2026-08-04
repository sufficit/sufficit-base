using System;

namespace Sufficit.Finance
{
    /// <summary>
    /// Represents a sanitized provider failure with a stable internal category.
    /// </summary>
    public class BankSlipGatewayException : Exception
    {
        public BankSlipGatewayException(
            BankSlipErrorCategory category,
            string errorCode,
            string message,
            int? httpStatusCode = null,
            string? providerChargeId = null,
            Exception? innerException = null,
            string? errorName = null,
            string? errorTitle = null,
            string? errorAction = null)
            : base(message, innerException)
        {
            Category = category;
            ErrorCode = errorCode;
            HttpStatusCode = httpStatusCode;
            ProviderChargeId = providerChargeId;
            ErrorName = errorName;
            ErrorTitle = errorTitle;
            ErrorAction = errorAction;
        }

        public BankSlipErrorCategory Category { get; }
        public string ErrorCode { get; }
        public int? HttpStatusCode { get; }
        public string? ProviderChargeId { get; }
        public string? ErrorName { get; }
        public string? ErrorTitle { get; }
        public string? ErrorAction { get; }
    }
}
