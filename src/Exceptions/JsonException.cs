using System;
using System.Runtime.Serialization;
using System.Text.Json.Serialization;

/// <summary>
/// Namespace no plural para evitar erros de correspondencia de nomes com outras apis
/// </summary>
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

        [Obsolete("2024/02/27 => use Sufficit.ExceptionsExtensions instead")]
        public static implicit operator JsonException? (System.Exception? ex)
        {
            if (ex == null) return null;

            var item = new JsonException();
            item.Type = ex.GetType().ToString();
            item.InnerException = ex.InnerException?.ToString();
            item.Message = ex.Message;

            if (ex.Data != null && ex.Data.Count > 0) 
                item.Data = ex.Data;

            return item;
        }

        public static implicit operator System.Exception (JsonException Ex)
            => new Exception(Ex.Message, new Exception(Ex.InnerException));          
    }
}
