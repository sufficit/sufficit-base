using System;
using System.Runtime.Serialization;
using System.Text.Json.Serialization;

/// <summary>
/// Namespace no plural para evitar erros de correspondencia de nomes com outras apis
/// </summary>
namespace Sufficit.EndPoints
{
    public interface IEndPointResponse
    {
        [JsonPropertyName("success"), JsonPropertyOrder(0)]
        [DataMember(EmitDefaultValue = true)]
        bool Success { get; }

        [JsonPropertyName("message"), JsonPropertyOrder(1)]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        [DataMember(EmitDefaultValue = false, IsRequired = false)]
        string? Message { get; }

        /// <summary>
        /// Help link 
        /// </summary>
        [JsonPropertyName("link"), JsonPropertyOrder(1)]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        [DataMember(EmitDefaultValue = false, IsRequired = false)]
        string? Link { get; }

        /// <summary>
        /// Serializable information ! Make sure that its serializable
        /// </summary>
        [JsonPropertyName("data"), JsonPropertyOrder(2)]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        [DataMember(EmitDefaultValue = false, IsRequired = false)]
        object? Data { get; }      
    }
}
