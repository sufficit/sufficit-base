using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace Sufficit.Cadences
{
    /// <summary>
    ///     Persistence of cadences. Save/Delete throw <see cref="InvalidOperationException"/> with a user facing message
    ///     on validation errors, stale versions, a second active cadence for the same target or deleting a non-draft.
    /// </summary>
    public interface ICadenceStore
    {
        Task<IEnumerable<Cadence>> Search(CadenceSearchParameters parameters, CancellationToken cancellationToken);

        Task<Cadence?> Get(Guid id, CancellationToken cancellationToken);

        /// <summary>Active cadence of a module and kind for the first candidate (most specific first) that has one.</summary>
        Task<Cadence?> Resolve(CadenceResolveRequest request, CancellationToken cancellationToken);

        Task<IEnumerable<CadenceRevision>> Revisions(Guid cadenceId, CancellationToken cancellationToken);

        Task<Cadence> Save(Cadence cadence, string? actor, CancellationToken cancellationToken);

        Task<bool> Delete(Guid id, CancellationToken cancellationToken);
    }
}
