using Sufficit.Telephony.Asterisk;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Sufficit.Telephony
{
    /// <summary>
    /// Methods to manipulate DIDs
    /// </summary>
    public interface DIDControllerInterface
    {
        /// <summary>
        /// Find a single or default object properties
        /// </summary>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        Task<DirectInwardDialing?> Find(Guid id, CancellationToken cancellationToken);

        Task<DirectInwardDialing?> Find(string extension, CancellationToken cancellationToken);

        Task<IEnumerable<DirectInwardDialing>> GetByContext(Guid contextId, CancellationToken cancellationToken);
    }
}
