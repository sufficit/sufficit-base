namespace Sufficit.Finance
{
    /// <summary>Audit snapshot of a manager's explicit eligibility change.</summary>
    public class CallCreditCommitmentPreferenceChange
    {
        public CallCreditCommitmentPreference Before { get; set; } = new CallCreditCommitmentPreference();
        public CallCreditCommitmentPreference After { get; set; } = new CallCreditCommitmentPreference();
    }
}
