using Sufficit.Events;
using System;

namespace Sufficit.Sales.Events
{
    /// <summary>
    ///     Shared contract for sales events that are relevant to telephony synchronization.
    /// </summary>
    public interface ITelephonyServiceContractEvent : IEvent, IContextId
    {
        /// <summary>
        ///     Recurring contract identifier.
        /// </summary>
        Guid ContractId { get; }

        /// <summary>
        ///     Related billing period identifier when the event was produced by a specific period.
        /// </summary>
        Guid? PeriodId { get; }

        /// <summary>
        ///     Related interruption identifier when the event originated from a pause, suspension, or outage.
        /// </summary>
        Guid? InterruptionId { get; }

        /// <summary>
        ///     External service key or commercial reference used by downstream modules.
        /// </summary>
        string? ContractKey { get; }

        /// <summary>
        ///     Friendly service title.
        /// </summary>
        string? ContractTitle { get; }

        /// <summary>
        ///     Current contract status at the time of publication.
        /// </summary>
        ContractStatus ContractStatus { get; }

        /// <summary>
        ///     UTC start date from which the event should be considered effective.
        /// </summary>
        DateTime? EffectiveFromUtc { get; }

        /// <summary>
        ///     UTC end date up to which the event should be considered effective.
        /// </summary>
        DateTime? EffectiveUntilUtc { get; }

        /// <summary>
        ///     UTC expiration date relevant to service enablement, balance validity, or policy enforcement.
        /// </summary>
        DateTime? ExpiresAtUtc { get; }

        /// <summary>
        ///     UTC due date associated with the related period when applicable.
        /// </summary>
        DateTime? DueDateUtc { get; }

        /// <summary>
        ///     UTC next due date calculated for the recurring contract when applicable.
        /// </summary>
        DateTime? NextDueDateUtc { get; }

        /// <summary>
        ///     Human-readable reason to help consumers understand why the event was emitted.
        /// </summary>
        string? Reason { get; }
    }
}
