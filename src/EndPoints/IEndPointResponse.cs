using System;
using System.Runtime.Serialization;
using System.Text.Json.Serialization;

namespace Sufficit.EndPoints
{
    public interface IEndPointResponse
    {
        /// <summary>
        ///     Indicates if the request was successful, default true
        /// </summary>
        /// <remarks>
        ///     * It's a successful result for API, 
        ///     not for database or controller itself, 
        ///     sometimes a delete operation won't result success (such as no records affected), 
        ///     but it's still an API success result because the object doesn't exists
        /// </remarks>
        [JsonPropertyName("success"), JsonPropertyOrder(0)]
        [DataMember(EmitDefaultValue = true)]
        bool Success { get; }

        [JsonPropertyName("message"), JsonPropertyOrder(1)]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        [DataMember(EmitDefaultValue = false, IsRequired = false)]
        string? Message { get; }

        /// <summary>
        ///     Help link 
        /// </summary>
        [JsonPropertyName("link"), JsonPropertyOrder(1)]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        [DataMember(EmitDefaultValue = false, IsRequired = false)]
        string? Link { get; }

        /// <summary>
        ///     Serializable information ! Make sure that its serializable
        /// </summary>
        [JsonPropertyName("data"), JsonPropertyOrder(2)]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        [DataMember(EmitDefaultValue = false, IsRequired = false)]
        object? Data { get; }      
    }
}
