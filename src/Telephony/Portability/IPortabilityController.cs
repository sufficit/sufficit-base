using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Sufficit.Telephony.Portability
{
    public interface IPortabilityController
    {
        /// <summary>
        ///     Get a portability process by id, with files
        /// </summary>
        Task<PortabilityProcess?> ById (Guid id, CancellationToken cancellationToken);

        IAsyncEnumerable<PortabilityProcess> SearchAsAsyncEnumerable(PortabilitySearchParameters parameters, CancellationToken cancellationToken);

        Task<IEnumerable<PortabilityProcess>> Search(PortabilitySearchParameters parameters, CancellationToken cancellationToken);

        /// <summary>
        ///     Add or update a portability process. If the process already exists, it will be updated.   
        /// </summary>
        /// <remarks>* If Files are not null, it will manage either</remarks>
        Task<PortabilityProcess?> AddOrUpdate(PortabilityProcess item, CancellationToken cancellationToken);

        /// <summary>
        ///     Remove a portability process by id, and all files related to it, if exists
        /// </summary>
        Task<int> Remove(Guid id, CancellationToken cancellationToken);
    }
}