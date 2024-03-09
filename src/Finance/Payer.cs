using System;
using System.Collections.Generic;
using System.Text;
using System.Text.Json.Serialization;

namespace Sufficit.Finance
{
    public class Payer
    {
        /// <summary>
        ///     Document Id, CPF or CNPJ ( Brazil )
        /// </summary>
        [JsonPropertyOrder(0)]
        [JsonPropertyName("document")]
        [JsonIgnore(Condition = JsonIgnoreCondition.Never)]
        public string Document { get; set; } = default!;

        [JsonPropertyOrder(1)]
        [JsonPropertyName("title")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull | JsonIgnoreCondition.WhenWritingDefault)]
        public string? Title { get; set; }
    }
}
