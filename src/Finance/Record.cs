using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sufficit.Finance
{
    public class Record
    {
        public Guid Id { get; set; }

        [DateTimeKind(DateTimeKind.Utc)]
        public DateTime Timestamp { get; set; }

        public decimal Value { get; set; }

        public string Kind { get; set; } = default!;

        public string Description { get; set; } = string.Empty;

        public string Document { get; set; } = string.Empty;

        public bool Active { get; set; }
    }

    public class ContextRecord : Record 
    {
        /// <summary>
        ///     CostCenter or Account
        /// </summary>
        public Guid ContextId { get; set; }

        /// <summary>
        ///     User|Member Id Tracked
        /// </summary>
        public Guid UserId { get; set; }
    }

    public class ContextRecordMsSql : ContextRecord
    {
        public int Code { get; set; }
    }
}
