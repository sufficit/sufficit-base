using System;
using System.Collections.Generic;
using System.Text;

namespace Sufficit.Contacts
{
    /// <summary>
    /// Represents a group of marker attributes, including a marker identifier and its associated usage count.
    /// </summary>
    /// <remarks>This struct is typically used to store and manage information about markers, such as their
    /// unique identifier and the number of occurrences or instances associated with them.</remarks>
    public struct MarkerAttributeGroup
    {
        public string Marker { get; set; }

        public uint Count { get; set; }
    }
}
