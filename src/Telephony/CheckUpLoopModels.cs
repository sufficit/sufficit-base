using System;
using System.Collections.Generic;

namespace Sufficit.Telephony
{
    public class LoopRequest : IIndex
    {
        public Guid Id { get; set; }

        public string? Status { get; set; }

        public HashSet<LoopItem> Items { get; } = new HashSet<LoopItem>();
    }

    public class LoopItem
    {
        public Guid id { get; set; }

        public int? length { get; set; }

        public double elapsed { get; set; }

        public string? error { get; set; }
    }
}
