using System;

namespace Sufficit.Contacts
{
    /// <summary>
    /// Contact search parameters
    /// </summary>
    public class ContactSearchParameters
    {
        /// <summary>Owner | Creator</summary>
        /// <example>00000000-0000-0000-0000-000000000000</example>
        public Guid? ContextId { get; set; }

        public TextFilter? Filter { get; set; }

        public uint Limit { get; set; }
    }
}
