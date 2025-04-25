using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Text;
using System.Text.Json.Serialization;

namespace Sufficit.EndPoints
{
    public class EndPointGenericResponse<T> : EndPointResponse
    {
        /// <summary>
        /// <inheritdoc cref="IEndPointResponse.Data"/>
        /// </summary>
        [JsonPropertyName("data"), JsonPropertyOrder(10)]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        [DataMember(EmitDefaultValue = false, IsRequired = false)]
        public new T Data { get => (T)base.Data!; set => base.Data = value; }
    }

    public class EndPointFullResponse<T> : EndPointGenericResponse<IEnumerable<T>>
    {
        [JsonPropertyName("total"), JsonPropertyOrder(2)]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingDefault)]
        public uint Total { get; set; }

        [JsonPropertyName("sortlabel"), JsonPropertyOrder(3)]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull | JsonIgnoreCondition.WhenWritingDefault)]
        public string? SortLabel { get;set; }

        [JsonPropertyName("sortdirection"), JsonPropertyOrder(3)]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull | JsonIgnoreCondition.WhenWritingDefault)]
        public string? SortDirection { get; set; }

        [JsonPropertyName("page"), JsonPropertyOrder(3)]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingDefault)]
        public uint Page { get; set; } = 0;

        [JsonPropertyName("pagesize"), JsonPropertyOrder(3)]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingDefault)]
        public uint PageSize { get; set; }
    }
}
