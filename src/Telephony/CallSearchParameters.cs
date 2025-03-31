using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Runtime.Serialization;
using System.Text.Json.Serialization;

namespace Sufficit.Telephony
{
    /// <summary>
    /// Parametros mínimos para o filtro de chamadas, o formato da data pode invalidar a consulta, portanto observe o exemplo !
    /// </summary>
    public class CallSearchParameters : ICallSearchParameters
    {
        [JsonIgnore]
        [Obsolete("use ContextId instead")]
        public Guid IDContext { get => ContextId; set => ContextId = value; }

        /// <inheritdoc cref="ICallSearchParameters.ContextId"/>
        /// <example>00000000-0000-0000-0000-000000000000</example>
        [Required]
        [JsonPropertyName("contextid")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingDefault)]
        public Guid ContextId { get; set; }

        /// <inheritdoc cref="ICallSearchParameters.Start"/>
        /// <example><code>DateTime.Today</code></example>
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingDefault)]
        [Required]
        public DateTime Start { get; set; }

        /// <inheritdoc cref="ICallSearchParameters.End"/>
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull | JsonIgnoreCondition.WhenWritingDefault)]
        public DateTime? End { get; set; }

        /// <inheritdoc cref="ICallSearchParameters.Region"/>
        [EnumDataType(typeof(RegionEnum))]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull | JsonIgnoreCondition.WhenWritingDefault)]
        //[JsonConverter(typeof(JsonStringEnumConverter))]
        public RegionEnum? Region { get; set; }

        /// <inheritdoc cref="ICallSearchParameters.DIDs"/>
        [DataMember(Name = "dids", IsRequired = false)]
        [JsonPropertyName("dids")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull | JsonIgnoreCondition.WhenWritingDefault)]
        public IEnumerable<string>? DIDs { get; set; }

        /// <inheritdoc cref="ICallSearchParameters.Billed"/>
        /// <example><code>false</code></example>
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public bool? Billed { get; set; }

        /// <inheritdoc cref="ICallSearchParameters.Answered"/>
        /// <example><code>false</code></example>
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public bool? Answered { get; set; }

        /// <inheritdoc cref="ICallSearchParameters.Limit"/>
        /// <example><code>0</code></example>
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingDefault)]
        public int Limit { get; set; }

        /// <inheritdoc cref="ICallSearchParameters.MaxRecords"/>
        /// <example><code>0</code></example>
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingDefault)]
        [JsonPropertyName("maxrecords")]
        public uint MaxRecords { get; set; }

        /// <inheritdoc cref="ICallSearchParameters.Protocol"/>
        [JsonPropertyName("protocol")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull | JsonIgnoreCondition.WhenWritingDefault)]
        public string? Protocol { get; set; }

        /// <inheritdoc cref="ICallSearchParameters.UniqueId"/>
        [JsonPropertyName("uniqueid")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull | JsonIgnoreCondition.WhenWritingDefault)]
        public string? UniqueId { get; set; }

        /// <inheritdoc cref="ICallSearchParameters.Filter"/>
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull | JsonIgnoreCondition.WhenWritingDefault)]
        public string? Filter { get; set; }

        /// <inheritdoc cref="ICallSearchParameters.Tags"/>
        [DataMember(Name = "tags", IsRequired = false)]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull | JsonIgnoreCondition.WhenWritingDefault)]
        public IEnumerable<string>? Tags { get; set; }

        /// <inheritdoc cref="ICallSearchParameters.TimeOut"/>
        [DataMember(Name = "timeout", IsRequired = false)]
        [JsonPropertyName("timeout")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull | JsonIgnoreCondition.WhenWritingDefault)]
        public TimeSpan? TimeOut { get; set; }
    }
}
