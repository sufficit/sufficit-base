namespace Sufficit.Telephony.Outbound
{
    /// <summary>Administrative permission to start a new outbound attempt.</summary>
    public enum OutboundAdministrativeState
    {
        Enabled = 1,
        Suspended = 2,
        Revoked = 3,
    }
}
