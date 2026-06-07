using System.Collections.Generic;

namespace Sufficit.Telephony
{
    /// <summary>
    ///     Collection of <see cref="PurgeReportItem"/> entries emitted by FreePBX purge operations.
    /// </summary>
    public class PurgeReportItems : HashSet<PurgeReportItem>
    {
        public PurgeReportItem Item { set => this.Add(value); }

        public IEnumerable<PurgeReportItem> Items { set { foreach (var item in value) this.Add(item); } }

        public void AddRange(IEnumerable<PurgeReportItem> items)
        {
            foreach (var item in items) this.Add(item);
        }

        public IEnumerable<PurgeReportItem> ToReadOnly() => this;
    }
}
