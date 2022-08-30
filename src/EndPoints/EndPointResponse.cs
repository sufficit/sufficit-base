﻿using Sufficit.Exceptions;
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
        [JsonPropertyName("success")]
        [DataMember(EmitDefaultValue = true)]
        public bool Success { get; set; } = true;

        [JsonPropertyName("message")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        [DataMember(EmitDefaultValue = false, IsRequired = false)]
        public string? Message { get; set; }

        [JsonPropertyName("data")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        [DataMember(EmitDefaultValue = false, IsRequired = false)]
        public object? Data { get; set; }      
    }
}
