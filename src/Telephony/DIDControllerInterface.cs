using System;
using System.Collections.Generic;
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
        Task<DirectInwardDialing?> GetById(Guid id, CancellationToken cancellationToken);

        Task<DirectInwardDialing?> GetByExtension(string extension, CancellationToken cancellationToken);

        Task<IEnumerable<DirectInwardDialing>> GetByContext(Guid contextId, CancellationToken cancellationToken);
    }
}
