using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.Serialization;
using System.Text;

namespace Sufficit
{
    /// <summary>
    /// Indicates the direction that search results are sorted by.
    /// </summary>
    public enum SortDirection
    {
        /// <summary>
        /// Results are sorted in descending order (Z-A).
        /// </summary>
        [EnumMember(Value = "descending")]
        [Description("descending")]
        Descending = -1,

        /// <summary>
        /// No sort direction.
        /// </summary>
        [EnumMember(Value = "none")]
        [Description("none")]
        None = 0,

        /// <summary>
        /// Results are sorted in ascending order (A-Z).
        /// </summary>
        [EnumMember(Value = "ascending")]
        [Description("ascending")]
        Ascending = 1,
    }    
}
