using System;
using System.Collections.Generic;
using System.Text;

namespace Sufficit.Storage
{
    public class StorageObject : StorageObjectMetadata
    {
        public byte[] Bytes { get; set; } = default!;
    }
}
