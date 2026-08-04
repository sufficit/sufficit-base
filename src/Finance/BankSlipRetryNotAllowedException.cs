using System;

namespace Sufficit.Finance
{
    /// <summary>
    /// Indicates that a bank slip cannot be manually queued for another issuance attempt.
    /// </summary>
    public sealed class BankSlipRetryNotAllowedException : Exception
    {
        public BankSlipRetryNotAllowedException(string message)
            : base(message)
        {
        }
    }
}
