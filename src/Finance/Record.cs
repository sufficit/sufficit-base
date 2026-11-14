using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sufficit.Finance
{
    /// <summary>
    ///     Default financial record
    /// </summary>
    public class Record
    {
        public Guid Id { get; set; }

        [DateTimeKind(DateTimeKind.Utc)]
        public DateTime Timestamp { get; set; }

        public decimal Value { get; set; }

        public string Kind { get; set; } = default!;

        /// <summary>
        ///     Entry kind identity (<see cref="LedgerEntryKinds"/>, fina_entry_kinds.id), filled by the database from
        ///     <see cref="Kind"/>. Prefer it over the text, which still carries former titles in old rows.
        /// </summary>
        public Guid? KindId { get; set; }

        public string Description { get; set; } = string.Empty;

        public string Document { get; set; } = string.Empty;

        public bool Active { get; set; }
    }
}
