using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;

namespace Sufficit.Gateway.Wavoip
{
    public class WavoipGateway
    {
        public Guid Id { get; set; }

        public Guid ContextId { get; set; }

        public string Token { get; set; } = default!;

        public string? Title { get; set; }

        public string? Description { get; set; }

        /// <summary>
        ///     Default asterisk destination
        /// </summary>
        public string? Asterisk { get; set; }

        public DateTime Expiration { get; set; }

        public DateTime Timestamp { get; set; }
    }
}
