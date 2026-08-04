using System;

namespace Sufficit.Finance
{
    /// <summary>
    /// Centralizes the conservative policy for explicit bank slip retries.
    /// </summary>
    public static class BankSlipRetryPolicy
    {
        /// <summary>
        /// Returns whether an operator may explicitly queue the same bank slip again.
        /// Security blocks, definitive rejections and ambiguous outcomes always require
        /// investigation or reconciliation instead of a provider mutation.
        /// </summary>
        public static bool CanRetry(BankSlipStatus status, string? errorCategory)
        {
            if (status != BankSlipStatus.Failed
                || !Enum.TryParse<BankSlipErrorCategory>(
                    errorCategory,
                    ignoreCase: true,
                    out var category))
            {
                return false;
            }

            return category is BankSlipErrorCategory.Validation
                or BankSlipErrorCategory.Retryable;
        }
    }
}
