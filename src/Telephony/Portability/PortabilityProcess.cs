using System;
using System.Collections.Generic;
using System.Text;
using System.Text.Json.Serialization;

namespace Sufficit.Telephony.Portability
{
    public class PortabilityProcess
    {
        /// <summary>
        ///     Unique process id
        /// </summary>
        [JsonPropertyName("id")]
        public Guid Id { get; set; }

        /// <summary>
        ///     Context (customer) unique id
        /// </summary>
        [JsonPropertyName("contextid")]
        public Guid ContextId { get; set; }

        /// <summary>
        ///     Title of current owner, name provided by a phone billet or personal document
        /// </summary>
        [JsonPropertyName("owner")]
        public string Owner { get; set; } = default!;

        /// <summary>
        ///     CPF | CPNJ (only numbers), from owner
        /// </summary>
        [JsonPropertyName("document")]
        public string Document { get; set; } = default!;

        /// <summary>
        ///     User Carrier source
        /// </summary>
        [JsonPropertyName("usercarriersrc")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull | JsonIgnoreCondition.WhenWritingDefault)]
        public string? UserCarrierSrc { get; set; }

        /// <summary>
        ///     Carrier source
        /// </summary>
        [JsonPropertyName("carriersrc")]
        public Guid CarrierSrc { get; set; }

        /// <summary>
        ///     Carrier destination
        /// </summary>
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull | JsonIgnoreCondition.WhenWritingDefault)]
        [JsonPropertyName("carrierdst")]
        public Guid? CarrierDst { get; set; }

        /// <summary>
        ///     Direct Inward Dialing <see cref="Telephony.DirectInwardDialing"/>
        /// </summary>
        [JsonPropertyName("did")]
        public string DID { get; set; } = default!;

        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull | JsonIgnoreCondition.WhenWritingDefault)]
        [JsonPropertyName("protocol")]
        public string? Protocol { get; set; }

        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull | JsonIgnoreCondition.WhenWritingDefault)]
        [JsonPropertyName("billet")]
        public string? Billet { get; set; }

        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull | JsonIgnoreCondition.WhenWritingDefault)]
        [JsonPropertyName("email")]
        public string? EMail { get; set; }

        [JsonPropertyName("status")]
        [JsonConverter(typeof(JsonStringEnumConverter))]
        public PortabilityProcessStatus Status { get; set; }

        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull | JsonIgnoreCondition.WhenWritingDefault)]
        [JsonPropertyName("message")]
        public string? Message { get; set; }

        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull | JsonIgnoreCondition.WhenWritingDefault)]
        [JsonPropertyName("schedule")]
        public DateTime? Schedule { get; set; }

        [JsonPropertyName("update")]
        public DateTime Update { get; set; }

        [JsonPropertyName("creation")]
        public DateTime Creation {  get; set; }

        /// <summary>
        ///    List of documents and files (ids) to be sent to the carrier
        /// </summary>
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull | JsonIgnoreCondition.WhenWritingDefault)]
        [JsonPropertyName("files")]
        public ICollection<Guid>? Files { get; set; }
    }
}
