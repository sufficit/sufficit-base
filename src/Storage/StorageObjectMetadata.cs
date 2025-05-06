using System;
using System.Collections.Generic;
using System.Text;
using System.Text.Json.Serialization;

namespace Sufficit.Storage
{
    public class StorageObjectMetadata
    {
        /// <summary>
        ///     Full path or sugested file name for the object
        /// </summary>
        [JsonPropertyName("fullpath")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingDefault)]
        public virtual string FullPath { get; set; } = default!;

        /// <summary>
        ///     Last update time
        /// </summary>
        [JsonPropertyName("update")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull | JsonIgnoreCondition.WhenWritingDefault)]
        public virtual DateTime? Update { get; set; }

        [JsonPropertyName("creation")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull | JsonIgnoreCondition.WhenWritingDefault)]
        public virtual DateTime? Creation { get; set; }

        [JsonPropertyName("mime")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull | JsonIgnoreCondition.WhenWritingDefault)]
        public string? MIME { get; set; }

        /// <summary>
        ///     (Optional) info about content length in bytes
        /// </summary>
        [JsonPropertyName("length")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull | JsonIgnoreCondition.WhenWritingDefault)]
        public ulong? Length { get; set; }

        /// <summary>
        ///     If storage does not allows to customize de creation datetime, use that custom time to specify custom events timestamp
        /// </summary>
        [JsonPropertyName("customtime")]
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
