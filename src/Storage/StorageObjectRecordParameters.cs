using System;
using System.Collections.Generic;
using System.Text;
using System.Text.Json.Serialization;

namespace Sufficit.Storage
{
    public class StorageObjectRecordParameters
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

        [JsonPropertyName("title")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull | JsonIgnoreCondition.WhenWritingDefault)]
        public string? Title { get; set; }

        [JsonPropertyName("section")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingDefault)]
        public StorageSection Section { get; set; }

        [JsonPropertyName("service")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingDefault)]
        public StorageService Service { get; set; }

        /// <summary>
        ///    Indicate that the object is marked for remove, even before the expiration date
        /// </summary>
        [JsonPropertyName("active")]
        public bool Active { get; set; } = true;

        /// <summary>
        ///     Last fisical data storage (service) check, indicates that the file still exists on storage
        /// </summary>
        [JsonPropertyName("check")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull | JsonIgnoreCondition.WhenWritingDefault)]
        public DateTime? Check { get; set; }

        /// <summary>
        ///     If set, the object will be automatic deleted after this date
        /// </summary>
        [JsonPropertyName("expiration")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull | JsonIgnoreCondition.WhenWritingDefault)]
        public DateTime? Expiration { get; set; }
    }
}
