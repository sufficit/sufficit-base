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
    public interface IMessagesController
    {
        /// <summary>
        ///     Get message details list, filtering and limiting
        /// </summary>
        Task<IEnumerable<MessageDetails>> GetDetails (MessageDetailsSearchParameters parameters, CancellationToken cancellationToken);

        /// <summary>
        ///     Get a single message details by message id, with or without content
        /// </summary>
        Task<MessageDetails?> GetDetails(Guid id, bool? content, CancellationToken cancellationToken);
    }
}
