using System;
using System.Threading;
using System.Threading.Tasks;

namespace Sufficit.Sales
{
    /// <summary>Read-only module boundary. Checking eligibility never changes a line or its expiration.</summary>
    public interface ILegacyServiceRenewalEligibility
    {
        Task<LegacyServiceRenewalEvidence> Read(Guid customer, string reference, CancellationToken token);
    }
    public sealed class LegacyServiceRenewalEvidence
    {
        public Guid CustomerId { get; set; }
        public Guid LineId { get; set; }
        public string Extension { get; set; } = string.Empty;
        public bool Billed { get; set; }
        public DateTime ObservedAtUtc { get; set; }
    }
}
