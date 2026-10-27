using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace Sufficit.Cadences
{
    /// <summary>
    ///     Persistence of cadences, cases and occurrences. User facing conflicts throw <see cref="InvalidOperationException"/>.
    /// </summary>
    public interface ICadenceStore
    {
        Task<IEnumerable<Cadence>> Search(CadenceSearchParameters parameters, CancellationToken cancellationToken);
        Task<Cadence?> Get(Guid id, CancellationToken cancellationToken);
        Task<IEnumerable<CadenceRevision>> Revisions(Guid cadenceId, CancellationToken cancellationToken);
        /// <summary>Saves a new version (already validated by the runtime).</summary>
        Task<Cadence> Save(Cadence cadence, string? actor, CancellationToken cancellationToken);
        Task<bool> Delete(Guid id, CancellationToken cancellationToken);

        Task<IEnumerable<CadenceCase>> SearchCases(CadenceCaseSearchParameters parameters, CancellationToken cancellationToken);
        Task<CadenceCase?> GetCase(Guid id, CancellationToken cancellationToken);
        /// <summary>Returns the existing open case for the same cadence and subject, or the new one (Created = true).</summary>
        Task<(CadenceCase Case, bool Created)> OpenCase(CadenceOpenCaseRequest request, string? actor, CancellationToken cancellationToken);
        Task<CadenceCase?> CloseCase(CadenceCloseCaseRequest request, CancellationToken cancellationToken);
        Task<(CadenceCase Case, DateTime PreviousAnchorDate)?> MoveAnchor(CadenceMoveAnchorRequest request, CancellationToken cancellationToken);

        Task<IReadOnlyList<CadenceCase>> OpenCases(CancellationToken cancellationToken);
        Task<IEnumerable<CadenceOccurrence>> Occurrences(Guid caseId, CancellationToken cancellationToken);
        /// <summary>Inserts the occurrence once per case and milestone key; false when it already existed.</summary>
        Task<bool> RecordOccurrence(CadenceOccurrence occurrence, CancellationToken cancellationToken);
    }
}
