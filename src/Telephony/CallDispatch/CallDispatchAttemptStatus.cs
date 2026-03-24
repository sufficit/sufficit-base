namespace Sufficit.Telephony.CallDispatch
{
    /// <summary>
    /// Lifecycle states for one persisted call dispatch attempt.
    /// </summary>
    public enum CallDispatchAttemptStatus
    {
        /// <summary>
        /// The attempt row was created and is waiting for execution.
        /// </summary>
        Pending = 0,

        /// <summary>
        /// The worker is executing the originate flow for this attempt.
        /// </summary>
        Running = 1,

        /// <summary>
        /// The originate flow returned without an unrecoverable error.
        /// </summary>
        Completed = 2,

        /// <summary>
        /// The originate flow ended with an unrecoverable error.
        /// </summary>
        Failed = 3,
    }
}