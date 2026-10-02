namespace Sufficit.Finance
{
    /// <summary>The authoritative event, independent of the credit's commercial origin.</summary>
    public enum CallCreditContributionTrigger
    {
        Unknown = 0,
        AuthorizedServiceActivation = 1,
        ConfirmedPayment = 2
    }
}
