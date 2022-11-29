using Sufficit.Exceptions;
using System;
using System.Runtime.Serialization;
using System.Text.Json.Serialization;

/// <summary>
/// Namespace no plural para evitar erros de correspondencia de nomes com outras apis
/// </summary>
namespace Sufficit.EndPoints
{
    [DataContract(Name = "response")]
    [Serializable]
    public class EndPointResponse : IEndPointResponse
    {
        /// <summary>
        /// <inheritdoc cref="IEndPointResponse.Success"/>
        /// </summary>
        [JsonPropertyName("success"), JsonPropertyOrder(0)]
        [DataMember(EmitDefaultValue = true)]
        public bool Success { get; set; } = true;

        /// <summary>
        /// <inheritdoc cref="IEndPointResponse.Message"/>
        /// </summary>
        [JsonPropertyName("message"), JsonPropertyOrder(1)]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        [DataMember(EmitDefaultValue = false, IsRequired = false)]
        public string? Message { get; set; }
        
        /// <summary>
        /// <inheritdoc cref="IEndPointResponse.Link"/>
        /// </summary>
        [JsonPropertyName("link"), JsonPropertyOrder(1)]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        [DataMember(EmitDefaultValue = false, IsRequired = false)]
        public string? Link { get; }

        /// <summary>
        /// <inheritdoc cref="IEndPointResponse.Data"/>
        /// </summary>
        [JsonPropertyName("data"), JsonPropertyOrder(2)]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        [DataMember(EmitDefaultValue = false, IsRequired = false)]
        public virtual object? Data { get; set; }      
    }
}
