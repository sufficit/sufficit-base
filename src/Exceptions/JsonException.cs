using System;
using System.Runtime.Serialization;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace Sufficit
{
    [DataContract(Name = "Exception")]
    [Serializable]
    public class JsonException
    {
        [JsonPropertyName("type")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull | JsonIgnoreCondition.WhenWritingDefault)]
        [DataMember(EmitDefaultValue = false)]
        public string? Type { get; set; }

        [JsonPropertyName("message")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull | JsonIgnoreCondition.WhenWritingDefault)]
        [DataMember(EmitDefaultValue = false)]
        public string? Message { get; set; }

        [JsonPropertyName("code")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull | JsonIgnoreCondition.WhenWritingDefault)]
        [DataMember(EmitDefaultValue = false)]
        public int? Code { get; set; }

        [JsonPropertyName("inner")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull | JsonIgnoreCondition.WhenWritingDefault)]
        [DataMember(EmitDefaultValue = false)]
        public string? InnerException { get; set; }

        /// <summary>
        ///     Extra content, serializable
        /// </summary>
        [JsonPropertyName("data")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull | JsonIgnoreCondition.WhenWritingDefault)]
        [DataMember(EmitDefaultValue = false)]
        public object? Data { get; set; }
        

        public static implicit operator System.Exception (JsonException Ex)
            => new Exception(Ex.Message, new Exception(Ex.InnerException));          
    }
}
