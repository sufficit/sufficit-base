namespace Sufficit.Telephony.Outbound
{
    /// <summary>How simultaneous contract lines of one service combine.</summary>
    public enum OutboundGrantAggregationPolicy
    {
        RejectOverlap = 1,
        SumChannels = 2,
        MaxChannels = 3,
    }
}
