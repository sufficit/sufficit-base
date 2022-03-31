using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sufficit
{
    /// <summary>
    /// Use this interface to identify object in collections
    /// </summary>
    public interface IIndex
    {
        /// <summary>
        /// Unique identifier of this object <br />
        /// Must be unique accross databases to identify on searches and navigations
        /// </summary>
        Guid ID { get; }
    }
}
