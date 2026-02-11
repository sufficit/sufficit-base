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

        /// <summary>
        ///     Add or update a note to a portability process
        ///     If note with same ProcessId + Timestamp exists, it will be updated
        /// </summary>
        Task<int> AddOrUpdateNote(PortabilityNote note, CancellationToken cancellationToken);

        /// <summary>
        ///     Get notes for a portability process, with optional filtering for public notes only
        /// </summary>
        Task<ICollection<PortabilityNote>> GetNotes(Guid id, bool? @public, CancellationToken cancellationToken);

        /// <summary>
        ///     Remove a specific note from a portability process by its timestamp
        /// </summary>
        Task<int> RemoveNote(Guid id, DateTime timestamp, CancellationToken cancellationToken);
    }
}