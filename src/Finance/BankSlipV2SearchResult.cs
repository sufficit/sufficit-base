using System;
using System.Collections.Generic;

namespace Sufficit.Finance
{
    /// <summary>
    /// Represents one paged bank slip v2 operational search result.
    /// </summary>
    public class BankSlipV2SearchResult
    {
        public IReadOnlyList<BankSlipV2View> Items { get; set; }
            = Array.Empty<BankSlipV2View>();

        public int Total { get; set; }
        public int Offset { get; set; }
        public int Limit { get; set; }
    }
}
