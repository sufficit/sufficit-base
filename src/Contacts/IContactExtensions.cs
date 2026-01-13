using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using System.Reflection;

namespace Sufficit.Contacts
{
    public static partial class IContactExtensions
    {
        /// <summary>
        ///     Ensures that Title property is not empty by filling with contact ID if blank.
        ///     Use this in UI components to prevent blank rows in tables/lists.
        /// </summary>
        public static string GetDisplay(this IContact source)
        {
            if (string.IsNullOrWhiteSpace(source.Title))
                return source.Id.ToString();
            
            return source.Title;
        }
    }
}
