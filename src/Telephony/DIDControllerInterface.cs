﻿using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace Sufficit.Telephony
{
    /// <summary>
    /// Methods to manipulate DIDs
    /// </summary>
    public interface DIDControllerInterface
    {
        /// <summary>
        /// Find a single or default object properties
        /// </summary>
        Task<DirectInwardDialing?> ById(Guid id, CancellationToken cancellationToken);

        Task<DirectInwardDialing?> ByExtension(string extension, CancellationToken cancellationToken);

        Task<IEnumerable<DirectInwardDialing>> ByContext(Guid contextId, CancellationToken cancellationToken);
    }
}
