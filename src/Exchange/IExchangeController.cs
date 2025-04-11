using Sufficit.Exchange.EMail;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Sufficit.Exchange
{
    /// <summary>
    ///     Used for sincronize API and Client public methods
    /// </summary>
    public interface IExchangeController
    {
        /// <summary>
        ///     UnSubscribe from a notification list, based on a message id
        /// </summary>
        Task UnSubscribe(Guid id, CancellationToken cancellationToken);

        /// <summary>
        ///     Gets the views information about a message, filtering by start and limit of responses 
        /// </summary>
        /// <remarks>*e-mails only for now</remarks>
        Task<IEnumerable<EMailTrackingInfo>> GetViews(ReadReceiptSearchParameters parameters, CancellationToken cancellationToken);
    }
}
