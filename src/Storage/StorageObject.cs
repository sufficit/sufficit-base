using System;
using System.Collections.Generic;
using System.Text;
using System.Text.Json.Serialization;

namespace Sufficit.Storage
{
    public class StorageObject : StorageObjectMetadata
    {
        [JsonPropertyName("bytes")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingDefault)]
        public byte[] Bytes { get; set; } = default!;

        public override bool Equals(object? obj)
            => obj is StorageObject other 
            && other.Bytes == Bytes 
            && base.Equals(other);

        public override int GetHashCode()
            => (Bytes).GetHashCode() ^ base.GetHashCode();
    }
}
