using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Text;
using System.Text.Json.Serialization;

namespace Sufficit.Gateway.SemanticUI
{
    [DataContract]
    public class SemanticUISearchAction
    {
        [JsonPropertyName("text")]
        public string Text { get; set; } = default!;

        /// <summary>
        ///  If empty, text will render as DIV
        /// </summary>
        [JsonPropertyName("url")]
        public string? Url { get; set; }
    }
}
