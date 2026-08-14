using System;
using System.Threading;
using System.Threading.Tasks;

namespace Sufficit.Finance
{
    /// <summary>
    /// Best-effort transport boundary for non-sensitive aggregate-change hints.
    /// The durable bank-slip store remains authoritative; consumers must reload
    /// the authorized resource instead of treating this notification as data.
    /// </summary>
    public interface IBankSlipChangePublisher
    {
        Task PublishAsync(
            BankSlipChange change,
            CancellationToken cancellationToken);
    }

    /// <summary>
    /// Transport-neutral subscription boundary for aggregate-change hints.
    /// HTTP hosts do not depend directly on Redis or cache infrastructure.
    /// </summary>
    public interface IBankSlipChangeSubscriber
    {
        Task<IAsyncDisposable> SubscribeAsync(
            Action<BankSlipChange> onChange,
            CancellationToken cancellationToken);
    }

    /// <summary>
    /// Shared transport names for bank-slip change notifications.
    /// </summary>
    public static class BankSlipChangeChannels
    {
        public const string AggregateChanged = "sufficit:finance:bankslips:changed";
    }
}
