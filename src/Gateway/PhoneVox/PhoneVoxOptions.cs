using System;
using System.Collections.Generic;
using System.Text;
using System.Text.Json.Serialization;

namespace Sufficit.Gateway.PhoneVox
{
    public class PhoneVoxOptions
    {
        [JsonPropertyName("id")]
        public Guid Id { get; set; }

        [JsonPropertyName("contextid")]
        public Guid ContextId { get; set; }

        [JsonPropertyName("server")]
        public RemoteServer Server { get; set; }
            = new RemoteServer();

        /// <summary>
        /// IXC | SGP
        /// </summary>
        [JsonPropertyName("system")]
        public string System { get; set; } = default!;

        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull | JsonIgnoreCondition.WhenWritingDefault)]
        [JsonPropertyName("app")]
        public string? App { get; set; }

        [JsonPropertyName("id_occurrence")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public ProviderIds? IdOccurrence { get; set; }

        [JsonPropertyName("id_section")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public ProviderIds? IdSection { get; set; }

        [JsonPropertyName("id_os")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public ProviderIds? IdOS { get; set; }
    }
}
