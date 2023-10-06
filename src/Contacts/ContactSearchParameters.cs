using System;
using System.Collections.Generic;

namespace Sufficit.Contacts
{
    /// <summary>
    ///     Contact search parameters
    /// </summary>
    public class ContactSearchParameters
    {
        /// <summary>Contact Id</summary>
        /// <example>00000000-0000-0000-0000-000000000000</example>
        public Guid? ContactId { get; set; }

        /// <summary>Owner | Creator</summary>
        /// <example>00000000-0000-0000-0000-000000000000</example>
        public Guid? ContextId { get; set; }

        public TextFilterWithKeys? Filter { get; set; }

        public uint Limit { get; set; }

        /// <summary>
        ///     Create contacts only with this attributes keys <br />
        ///     If null, all attributes will be used
        /// </summary>
        public HashSet<string>? Keys { get; set; }
    }
}
