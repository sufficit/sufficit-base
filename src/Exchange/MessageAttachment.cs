using System;
using System.Collections.Generic;
using System.Text;
using System.Text.Json.Serialization;

namespace Sufficit.Exchange
{
    public class MessageAttachment
    {
        /// <summary>
        /// Propriedade que indica o tipo de conteudo do anexo
        /// </summary>
        [JsonPropertyName("mime")]
        public string? MIME { get; set; }


        [JsonPropertyName("content")]
        public byte[] Content { get; set; } = default!;

        /// <summary>
        ///  Sugestão para nome de arquivo
        /// </summary>
        [JsonPropertyName("filename")]
        public string? FileName { get; set; }
    }
}
