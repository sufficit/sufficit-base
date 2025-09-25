using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json.Serialization;

namespace Sufficit.Storage
{
    /// <summary>
    ///     Storage object metadata, used by storage database providers
    /// </summary>
    /// <remarks>*not real files, only sql meta data</remarks>
    public class StorageObjectRecord
    {
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingDefault)]
        [JsonPropertyName("id")]
        public Guid Id { get; set; }

        [JsonPropertyName("contextid")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingDefault)]
        public Guid ContextId { get; set; }

        [JsonPropertyName("memberid")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull | JsonIgnoreCondition.WhenWritingDefault)]
        public Guid? MemberId { get; set; }

        /// <summary>
        ///     Any title as sugested file name with extension
        /// </summary>
        [JsonPropertyName("title")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull | JsonIgnoreCondition.WhenWritingDefault)]
        public string? Title { get; set; }

        /// <summary>
        ///     Public accessible url for the object
        /// </summary>
        [JsonPropertyName("url")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull | JsonIgnoreCondition.WhenWritingDefault)]
        public string? Url { get; set; }

        [JsonPropertyName("section")]
        public StorageSection Section { get; set; }

        [JsonPropertyName("service")]
        public StorageService Service { get; set; }

        /// <summary>
        ///    Indicate that the object is marked for remove, even before the expiration date
        /// </summary>
        [JsonPropertyName("active")]
        public bool Active { get; set; } = true;

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
        ///     Last fisical data storage (service) check, indicates that the file still exists on storage
        /// </summary>
        [JsonPropertyName("check")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull | JsonIgnoreCondition.WhenWritingDefault)]
        public DateTime? Check { get; set; }

        /// <summary>
        ///     Last update time
        /// </summary>
        [JsonPropertyName("update")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull | JsonIgnoreCondition.WhenWritingDefault)]
        public virtual DateTime? Update { get; set; }

        [JsonPropertyName("creation")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull | JsonIgnoreCondition.WhenWritingDefault)]
        public virtual DateTime? Creation { get; set; }

        /// <summary>
        ///     If set, the object will be automatic deleted after this date
        /// </summary>
        [JsonPropertyName("expiration")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull | JsonIgnoreCondition.WhenWritingDefault)]
        public DateTime? Expiration { get; set; }

        /// <summary>
        ///     Flexible tagging system for file classification and permissions
        ///     Examples: "admin", "internal", "portability-admin", "public"
        /// </summary>
        [JsonPropertyName("tags")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull | JsonIgnoreCondition.WhenWritingDefault)]
        public virtual HashSet<string>? Tags { get; set; }

        [JsonIgnore]
        public string? TagCollection
        {
            get => Tags == null || !Tags.Any() ? null : string.Join(',', Tags.Select(t => $"\"{t}\""));
            set => Tags = string.IsNullOrWhiteSpace(value) ? null : value.Split(',', StringSplitOptions.RemoveEmptyEntries | StringSplitOptions.TrimEntries).Select(t => t.Trim('"')).ToHashSet();
        }
    }
}
