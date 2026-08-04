namespace Sufficit.Finance
{
    /// <summary>
    /// Represents the stable internal classification of provider errors.
    /// </summary>
    public enum BankSlipErrorCategory : byte
    {
        Validation = 1,
        SecurityBlock = 2,
        DefinitiveRejection = 3,
        Retryable = 4,
        AmbiguousResult = 5,
        ProviderUnavailable = 6
    }
}
