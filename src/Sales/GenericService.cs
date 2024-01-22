using System;
using System.Collections.Generic;
using System.Text;

namespace Sufficit.Sales
{
    /// <summary>
    ///     Sales service, intangible act or performance
    /// </summary>
    public class GenericService : IService
    {
        /// <inheritdoc cref="IService.Title"/>
        public virtual string Title { get; set; } = default!;

        /// <inheritdoc cref="IService.Description"/>
        public virtual string? Description { get; set; }

        /// <inheritdoc cref="IService.Extra"/>
        public virtual string? Extra { get; set; }

        /// <inheritdoc cref="IService.Value"/>
        public decimal Value { get; set; }
    }
}
