using System;
using System.Collections.Generic;
using System.Text;

namespace Sufficit
{
    [Flags]
    public enum UpdateOperations
    {
        /// <summary>
        ///     No operations were performed on the resource
        /// </summary>
        None = 0,

        Add = 1,
        Change = 2,
        Delete = 4,
    }
}
