using System;

namespace Sufficit.Cadences
{
    /// <summary>Owner module opens a case. Idempotent per cadence + subject while the case is open.</summary>
    public sealed class CadenceOpenCaseRequest
    {
        public Guid CadenceId { get; set; }
        public string SubjectType { get; set; } = string.Empty;
        public string SubjectId { get; set; } = string.Empty;
        public Guid? ContextId { get; set; }
        public DateTime AnchorDate { get; set; }
    }

    public sealed class CadenceCloseCaseRequest
    {
        public Guid CaseId { get; set; }
        /// <summary>Free reason defined by the owner (e.g. "resolved", "cancelled").</summary>
        public string Reason { get; set; } = "resolved";
    }

    public sealed class CadenceMoveAnchorRequest
    {
        public Guid CaseId { get; set; }
        public DateTime AnchorDate { get; set; }
    }

    public sealed class CadenceCaseSearchParameters
    {
        public Guid? CadenceId { get; set; }
        public string? SubjectType { get; set; }
        public string? SubjectId { get; set; }
        public Guid? ContextId { get; set; }
        public CadenceCaseStatus? Status { get; set; }
        public int Limit { get; set; } = 200;
    }

    /// <summary>Result of one tick.</summary>
    public sealed class CadenceRunResult
    {
        public DateTime ReferenceDate { get; set; }
        public int CasesEvaluated { get; set; }
        public int Emitted { get; set; }
        public int Late { get; set; }
        public bool Simulated { get; set; }
    }
}
