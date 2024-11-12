using System;
using System.Collections.Generic;
using System.Text;
using System.Text.Json.Serialization;

namespace Sufficit.Storage
{
    public class StorageObjectMetadata
    {
        public string FullPath { get; set; } = default!;

        /// <summary>
        ///     Last update time
        /// </summary>
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull | JsonIgnoreCondition.WhenWritingDefault)]
        public DateTime? Update { get; set; }

        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull | JsonIgnoreCondition.WhenWritingDefault)]
        public DateTime? Creation { get; set; }

        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull | JsonIgnoreCondition.WhenWritingDefault)]
        public string? MIME { get; set; }

        /// <summary>
        ///     (Optional) info about content length in bytes
        /// </summary>
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull | JsonIgnoreCondition.WhenWritingDefault)]
        public ulong? Length { get; set; }

        /// <summary>
        ///     If storage does not allows to customize de creation datetime, use that custom time to specify custom events timestamp
        /// </summary>
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull | JsonIgnoreCondition.WhenWritingDefault)]
        public DateTime? CustomTime { get; set; }

        public override bool Equals(object? obj)
            => obj is StorageObjectMetadata other 
            && other.FullPath == FullPath 
            && other.Update == Update
            && other.Creation == Creation
            && other.MIME == MIME
            && other.Length == Length
            && other.CustomTime == CustomTime;

        public override int GetHashCode()
            => (FullPath, Update, Creation, MIME, Length, CustomTime).GetHashCode();
    }
}
