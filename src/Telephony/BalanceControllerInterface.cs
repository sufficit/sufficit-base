using System;
using System.Collections.Generic;
using System.Data;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Sufficit.Telephony
{
    public interface BalanceControllerInterface
    {
        /// <summary>
        /// Informe balance update event and dispach relative events
        /// </summary>
        Task Notify(BalanceNotifyRequest request, CancellationToken cancellationToken);

        /// <summary>
        /// Update balance informations like limits
        /// </summary>
        Task Patch(BalancePatchRequest request, CancellationToken cancellationToken);

        /// <summary>
        /// Returns current balance for calls
        /// </summary>
        Task<Balance?> Get(Guid contextId, CancellationToken cancellationToken);

        /// <summary>
        /// Returns current balance amount for calls
        /// </summary>
        Task<decimal?> GetAmount(Guid contextId, CancellationToken cancellationToken);
    }
}
