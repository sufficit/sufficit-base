using System;
using System.Collections.Generic;
using System.Text;
using System.Text.Json.Serialization;

namespace Sufficit.Finance
{
    public class Assignor
    {
        /// <summary>
        ///     Bank account title
        /// </summary>
        [JsonPropertyOrder(0)]
        [JsonPropertyName("title")]
        [JsonIgnore(Condition = JsonIgnoreCondition.Never)]
        public string Title { get; set; } = default!;

        /// <summary>
        ///     Bank unique account code
        /// </summary>
        [JsonPropertyOrder(1)]
        [JsonPropertyName("account")]
        [JsonIgnore(Condition = JsonIgnoreCondition.Never)]
        public string Account { get; set; } = default!;

        /// <summary>
        ///     Bankslip number or id order from bank
        /// </summary>
        [JsonPropertyOrder(2)]
        [JsonPropertyName("position")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull | JsonIgnoreCondition.WhenWritingDefault)]
        public string? Position { get; set; }

        /// <summary>
        ///     Document Id, Token, etc
        /// </summary>
        [JsonPropertyOrder(2)]
        [JsonPropertyName("token")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull | JsonIgnoreCondition.WhenWritingDefault)]
        public string? Token { get; set;}
    }
}
