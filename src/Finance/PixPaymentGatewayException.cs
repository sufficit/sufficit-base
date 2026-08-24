using System;

namespace Sufficit.Finance
{

    public sealed class PixPaymentGatewayException : Exception
    {
        public PixPaymentGatewayException(
            PixPaymentErrorCategory category,
            string errorCode,
            string message,
            int? httpStatusCode = null,
            string? providerChargeId = null,
            Exception? innerException = null)
            : base(message, innerException)
        {
            Category = category;
            ErrorCode = errorCode;
            HttpStatusCode = httpStatusCode;
            ProviderChargeId = providerChargeId;
        }

        public PixPaymentErrorCategory Category { get; }
        public string ErrorCode { get; }
        public int? HttpStatusCode { get; }
        public string? ProviderChargeId { get; }
    }

    public enum PixPaymentErrorCategory : byte
    {
        Validation = 0,
        Retryable = 1,
        ProviderUnavailable = 2,
        AmbiguousResult = 3,
        SecurityBlock = 4,
        DefinitiveRejection = 5
    }
}
