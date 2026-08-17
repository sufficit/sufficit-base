using System;

namespace Sufficit.Finance
{
#if NETSTANDARD2_0
    /// <summary>
    /// Compatibility contract consumed by the last EFData netstandard2.0 asset.
    /// </summary>
    [Obsolete("Use LegacyBankSlipSearchParameters for the legacy bank-slip surface.")]
    public class BankSlipSearchParameters : LegacyBankSlipSearchParameters
    {
    }
#else
    /// <summary>
    /// Defines tenant-scoped filters for bank-slip operational searches.
    /// </summary>
    public class BankSlipSearchParameters
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
#endif
}
