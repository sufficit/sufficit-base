using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Sufficit.Finance
{
    public class BalanceTransfer
    {
        public Guid Id { get; set; }

        [DateTimeKind(DateTimeKind.Utc)]
        public DateTime Timestamp { get; set; }

        /// <summary>
        ///     Always positive relative value
        /// </summary>
        public decimal Amount { get; set; }

        public string Description { get; set; } = string.Empty;

        public virtual Guid SourceId { get; set; } = default!;

        public virtual Guid DestinationId { get; set; } = default!;

        /// <summary>
        ///     User|Member Id Tracked
        /// </summary>
        public Guid UserId { get; set; }

        public bool Active { get; set; }
    }
}
