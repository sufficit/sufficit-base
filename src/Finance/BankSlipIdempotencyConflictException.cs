using System;

namespace Sufficit.Finance
{
    /// <summary>
    /// Indicates reuse of an idempotency key with a different issuance payload.
    /// </summary>
    public class BankSlipIdempotencyConflictException : Exception
    {
        public BankSlipIdempotencyConflictException()
            : base("The idempotency key is already associated with a different bank slip request.")
        {
        }
    }
}
