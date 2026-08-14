using System;
using System.Collections.Generic;

namespace Sufficit.Finance
{
    /// <summary>
    /// Represents one paged bank-slip operational search result.
    /// </summary>
    public class BankSlipSearchResult
    {
        public IReadOnlyList<BankSlipView> Items { get; set; }
            = Array.Empty<BankSlipView>();

        public int Total { get; set; }
        public int Offset { get; set; }
        public int Limit { get; set; }
    }
}
