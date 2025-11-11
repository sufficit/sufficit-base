namespace Sufficit.Telephony.Asterisk
{
    /// <summary>
    /// Asterisk CDR (Call Detail Record) disposition values indicating the final status of a call.
    /// </summary>
    /// <remarks>
    /// Disposition is set when a call completes and indicates what happened to it. <br />
    /// Reference: Asterisk CDR disposition field documentation <br />
    /// https://docs.asterisk.org/Asterisk_18_Documentation/API_Documentation/Dialplan_Functions/CDR/
    /// </remarks>
    public enum AsteriskChannelDisposition
    {
        /// <summary>
        /// Unknown or undefined disposition state.
        /// </summary>
        UNKNOWN = 0,

        /// <summary>
        /// The called party was busy - received BUSY signal from the destination.
        /// Indicates the destination device was in use and could not accept the call.
        /// </summary>
        BUSY = 1,

        /// <summary>
        /// Network or system congestion prevented call completion.
        /// Indicates insufficient resources (channels, bandwidth, etc.) to complete the call.
        /// Similar to a reorder tone or fast busy signal.
        /// </summary>
        CONGESTION = 2,

        /// <summary>
        /// Call attempt failed due to technical issues.
        /// May indicate invalid number, routing problems, or protocol errors.
        /// Different from NOANSWER - this is a failure before ringing could start.
        /// </summary>
        FAILED = 3,

        /// <summary>
        /// Call was not answered - destination rang but no one picked up.
        /// The called party did not answer within the timeout period.
        /// Typically indicates the call rang but was not answered by a human or device.
        /// </summary>
        NOANSWER = 4,

        /// <summary>
        /// Call is currently in ringing state.
        /// Indicates the destination is being alerted but has not yet answered.
        /// This is typically a transient state during active calls.
        /// </summary>
        RINGING = 5,

        /// <summary>
        /// Call was successfully answered and connected.
        /// Indicates the called party answered the call and a conversation could occur.
        /// This is the only disposition that typically results in billable time (billsec > 0).
        /// </summary>
        ANSWERED = 6
    }
}
