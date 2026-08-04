using System;

namespace Sufficit.Finance
{
    /// <summary>
    /// Defines tenant-scoped filters for bank slip v2 operational searches.
    /// </summary>
    public class BankSlipV2SearchParameters
    {
        public Guid? ContextId { get; set; }
        public BankSlipStatus? Status { get; set; }
        public string? Provider { get; set; }
        public DateTime? CreatedFromUtc { get; set; }
        public DateTime? CreatedToUtc { get; set; }
        public bool OperationalAlertOnly { get; set; }
        public int Offset { get; set; }
        public int Limit { get; set; } = 25;
    }
}
