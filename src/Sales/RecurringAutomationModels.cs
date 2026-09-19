using System;
using System.Collections.Generic;

namespace Sufficit.Sales
{
    /// <summary>Bounded scheduler request. Business date is chosen by the central API.</summary>
    public sealed class RecurringAutomationRequest
    {
        public int Skip { get; set; }
        public int Take { get; set; } = 100;
    }

    /// <summary>Per-contract outcomes for a page; replay never creates a charge.</summary>
    public sealed class RecurringAutomationResult
    {
        public DateTime CompletedAtUtc { get; set; }
        public int NextSkip { get; set; }
        public bool HasMore { get; set; }
        public int Processed { get; set; }
        public int Skipped { get; set; }
        public List<Guid> FailedContractIds { get; set; } = new List<Guid>();
    }
}
