using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sufficit.Telephony
{
    /// <summary>
    /// Extension Dial Alias
    /// </summary>
    public class EndPointAlias : ITimestamp
    {
        public Guid EndPointId { get; set; }

        public Guid ContextId { get; set; }

        public string Alias { get; set; } = default!;

        public string? Title { get; set; }

        /// <summary>
        ///     <see cref="EndPointAliasKind.Dial"/> (context-scoped dial shortcut, default) or
        ///     <see cref="EndPointAliasKind.Login"/> (system-wide PJSIP registration name).
        /// </summary>
        public string Kind { get; set; } = EndPointAliasKind.Dial;

        public DateTime CreatedAtUtc { get; set; }

        public DateTime? UpdatedAtUtc { get; set; }

        public DateTime? DeletedAtUtc { get; set; }
    }
}
