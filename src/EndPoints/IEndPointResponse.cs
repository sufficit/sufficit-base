using Sufficit.Exceptions;
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
        [JsonPropertyName("success")]
        [DataMember(EmitDefaultValue = true)]
        bool Success { get; }

        [JsonPropertyName("message")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        [DataMember(EmitDefaultValue = false, IsRequired = false)]
        string? Message { get; }

        [JsonPropertyName("data")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        [DataMember(EmitDefaultValue = false, IsRequired = false)]
        object? Data { get; }      
    }
}
