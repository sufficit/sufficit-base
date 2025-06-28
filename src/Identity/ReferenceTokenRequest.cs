using System;
using System.Collections.Generic;
using System.Text;

namespace Sufficit.Identity
{
    public class ReferenceTokenRequest
    {
        /// <summary>
        /// Gets or sets the expiration date and time for the associated resource or operation.
        /// </summary>
        public DateTimeOffset? Expiration { get; set; }

        /// <summary>
        /// Gets or sets the description associated with the object.
        /// </summary>
        public string? Description { get; set; }
    }
}
