namespace Sufficit.Sales.Events
{
    /// <summary>
    ///     Lifecycle change kinds that telephony may care about without subscribing to every sales event individually.
    /// </summary>
    public enum TelephonyServiceContractChangeType : byte
    {
        /// <summary>
        ///     A recurring service was created.
        /// </summary>
        Created = 0,

        /// <summary>
        ///     A recurring service was updated without changing its lifecycle semantics.
        /// </summary>
        Updated = 1,

        /// <summary>
        ///     A recurring service became active.
        /// </summary>
        Activated = 2,

        /// <summary>
        ///     A recurring service was paused.
        /// </summary>
        Paused = 3,

        /// <summary>
        ///     A recurring service resumed after a pause or interruption.
        /// </summary>
        Resumed = 4,

        /// <summary>
        ///     A recurring service was suspended for administrative or financial reasons.
        /// </summary>
        Suspended = 5,

        /// <summary>
        ///     A pause, suspension, outage, or maintenance window was registered against the service.
        /// </summary>
        InterruptionRegistered = 6,

        /// <summary>
        ///     A previously registered pause, suspension, outage, or maintenance window was removed.
        /// </summary>
        InterruptionRemoved = 7,

        /// <summary>
        ///     A recurring service was canceled.
        /// </summary>
        Canceled = 8,

        /// <summary>
        ///     A recurring service expired naturally.
        /// </summary>
        Expired = 9,

        /// <summary>
        ///     A billing period was explicitly closed.
        /// </summary>
        PeriodClosed = 10,

        /// <summary>
        ///     A billing period was reopened.
        /// </summary>
        PeriodReopened = 11,

        /// <summary>
        ///     A billing period was force recalculated.
        /// </summary>
        PeriodForceRecalculated = 12,
    }
}
