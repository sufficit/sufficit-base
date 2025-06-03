using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Runtime.Serialization;
using System.Text;
using System.Text.Json.Serialization;

namespace Sufficit.Telephony
{
    /// <summary>
    ///     Caller Identification
    /// </summary>
    public class CallerIdInfo
    {
        /// <summary>
        ///     Number any format
        /// </summary>
        /// <remarks>* only numbers</remarks>        
        [JsonPropertyName("number")]
        public string Number { get; set; } = Sufficit.Telephony.Asterisk.Constants.MissingNumber;

        /// <summary>
        ///     E164 format number
        /// </summary>       
        [JsonPropertyName("e164")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull | JsonIgnoreCondition.WhenWritingDefault)]
        public string? E164 { get; set; }

        /// <summary>
        ///     Name label
        /// </summary>       
        [JsonPropertyName("name")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull | JsonIgnoreCondition.WhenWritingDefault)]
        public string? Name { get; set; }
    }
}
