using System;
using System.Collections.Generic;
using System.Text;

namespace Sufficit.Notification
{
    public class BoardNotification
    {
        public Guid RuleId { get; set; }
        
        public Guid ContextId { get; set; }

        public Guid? ModelId { get; set; }

        public Guid? ReferenceId { get; set; }

        public string Message { get; set; } = default!;

        /// <summary>
        /// Link to action or help
        /// </summary>
        public string? HelpLink { get; set; }
    }
}
