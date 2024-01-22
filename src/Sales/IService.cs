using System;
using System.Collections.Generic;
using System.Text;

namespace Sufficit.Sales
{
    /// <summary>
    ///     Sales service, intangible act or performance
    /// </summary>
    public interface IService
    {
        /// <summary>
        ///     Service type
        /// </summary>
        string Title { get; }

        /// <summary>
        ///     Description or exclusive details
        /// </summary>
        string? Description { get; }

        /// <summary>
        ///     Extra information or parameters
        /// </summary>
        string? Extra { get; }

        /// <summary>
        ///     Price
        /// </summary>
        decimal Value { get; }
    }
}
