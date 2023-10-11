using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using System.Reflection;

namespace Sufficit.Contacts
{
    public static class ContactWithAttributesExtensions
    {
        /// <summary>
        ///     Return the value of first found key
        /// </summary>
        public static string? GetValue(this ContactWithAttributes source, string key, string? description = null)
        {
            var ordered = source.Attributes.Where(s => s.Key == key.Trim().ToLower()).OrderBy(s => s.Description);

            Attribute? attribute = null;

            if (description != null)
                attribute = ordered.FirstOrDefault(s => s.Description == description);

            return attribute?.Value ?? ordered.FirstOrDefault()?.Value;
        }
    }
}
