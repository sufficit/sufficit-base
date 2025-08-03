using System;
using System.Collections.Generic;
using System.Text;
using System.Text.Json.Serialization;

namespace Sufficit.Telephony.Portability
{
    public class PortabilityProcessFilesUpdateRequest
    {
        /// <summary>
        ///     Unique process id
        /// </summary>
        [JsonPropertyName("id")]
        public Guid Id { get; set; }

        /// <summary>
        ///    List of documents and files (ids) to be sent to the carrier
        /// </summary>
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull | JsonIgnoreCondition.WhenWritingDefault)]
        [JsonPropertyName("files")]
        public ICollection<Guid>? Files { get; set; }
    }
}
