using System;
using System.Collections.Generic;
using System.Text;

namespace Sufficit.Storage
{
    public class StorageObjectMetadata
    {
        public string FullPath { get; set; } = default!;

        /// <summary>
        ///     Last update time
        /// </summary>
        public DateTime? Update { get; set; }

        public DateTime? Creation { get; set; }

        public string? MIME { get; set; }
    }
}
