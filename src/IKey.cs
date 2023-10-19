using System;
using System.Collections.Generic;
using System.Text;

namespace Sufficit
{
    /// <summary>
    ///     Interface to grants unique identifiers based on string key
    /// </summary>
    public interface IKey
    {
        /// <summary>
        ///     Unique composite string key
        /// </summary>
        string Key { get; }
    }
}
