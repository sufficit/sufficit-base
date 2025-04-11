using System;
using System.Diagnostics.CodeAnalysis;
using System.Net.Http;
using System.Runtime.Serialization;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace Sufficit
{
    /// <summary>
    ///   Default exception for json serialization
    /// </summary>
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

        #region IMPLICIT CONVERTERS, JUST THIS EXCEPTION FOR BASE PACKAGE !

        public static implicit operator System.Exception (JsonException source)
            => new Exception(source.Message, new Exception(source.InnerException));

#if !NETSTANDARD
        [return: NotNullIfNotNull(nameof(source))]
#endif
        public static implicit operator JsonException? (System.Exception? source)
        {
            if (source == null) return null;

            var item = new JsonException
            {
                Type = source.GetType().ToString(),
                InnerException = source.InnerException?.ToString(),
                Message = source.Message
            };

            if (source.Data != null && source.Data.Count > 0)
                item.Data = source.Data; // used by receitanet

            if (source is HttpRequestException http)
            {
#if NET5_0_OR_GREATER
                item.Code = (int?)http.StatusCode;
#endif
            }

            return item;
        }

        #endregion
    }
}
