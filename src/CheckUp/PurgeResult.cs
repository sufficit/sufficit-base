using Sufficit.Telephony;
using System;
using System.Collections.Generic;

namespace Sufficit.CheckUp
{
    public class PurgeResult
    {
        public int Total => Items.Count;

        public HashSet<PurgeResultItem> Items { get; set; } = new HashSet<PurgeResultItem>();
    }

    public class PurgeResultItem
    {
        public Guid ContextId { get; set; }

        public DateTime Expiration { get; set; }

        public uint Code { get; set; }

        public string? Title { get; set; }

        public IEnumerable<PurgeReportItem>? Purge { get; set; }
    }
}
