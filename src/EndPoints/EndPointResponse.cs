using System;
using System.Runtime.Serialization;
using System.Text.Json.Serialization;

namespace Sufficit.EndPoints
{
    /// <summary>
    ///     Generic <typeparamref name="T"/> endpoint response
    /// </summary>
    /// <typeparam name="T"></typeparam>
    [DataContract(Name = "response")]
    [Serializable]
    public class EndPointResponse<T> : EndPointResponse
    {        
        /// <inheritdoc cref="IEndPointResponse.Data"/>
        [JsonPropertyName("data"), JsonPropertyOrder(10)]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        [DataMember(EmitDefaultValue = false, IsRequired = false)]
        public new T Data { get => (T)base.Data!; set => base.Data = value; }
    }

    /// <summary>
    ///     Default API endpoint response
    /// </summary>
    [DataContract(Name = "response")]
    [Serializable]
    public class EndPointResponse : IEndPointResponse
    {        
        /// <inheritdoc cref="IEndPointResponse.Success"/>
        [JsonPropertyName("success"), JsonPropertyOrder(0)]
        [DataMember(EmitDefaultValue = true)]
        public bool Success { get; set; } = true;

        /// <inheritdoc cref="IEndPointResponse.Message"/>
        [JsonPropertyName("message"), JsonPropertyOrder(1)]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        [DataMember(EmitDefaultValue = false, IsRequired = false)]
        public string? Message { get; set; }
        
        /// <inheritdoc cref="IEndPointResponse.Link"/>
        [JsonPropertyName("link"), JsonPropertyOrder(1)]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        [DataMember(EmitDefaultValue = false, IsRequired = false)]
        public string? Link { get; set; }

        /// <inheritdoc cref="IEndPointResponse.Data"/>
        [JsonPropertyName("data"), JsonPropertyOrder(2)]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        [DataMember(EmitDefaultValue = false, IsRequired = false)]
        public virtual object? Data { get; set; }      
    }
}
