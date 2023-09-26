using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Runtime.Serialization;

namespace Sufficit.Telephony
{
    /// <summary>
    /// Parametros mínimos para o filtro de chamadas, o formato da data pode invalidar a consulta, portanto observe o exemplo !
    /// </summary>
    public class CallSearchParameters : ICallSearchParameters
    {
        /// <inheritdoc cref="ICallSearchParameters.IDContext"/>
        /// <example>00000000-0000-0000-0000-000000000000</example>
        [Required]
        public Guid IDContext { get; set; }

        /// <inheritdoc cref="ICallSearchParameters.Start"/>
        /// <example><code>DateTime.Today</code></example>
        [Required]
        public DateTime Start { get; set; }

        /// <inheritdoc cref="ICallSearchParameters.End"/>
        public DateTime? End { get; set; }

        /// <inheritdoc cref="ICallSearchParameters.Region"/>
        [EnumDataType(typeof(RegionEnum))]
        //[JsonConverter(typeof(JsonStringEnumConverter))]
        public RegionEnum? Region { get; set; }

        /// <inheritdoc cref="ICallSearchParameters.DIDs"/>
        [DataMember(Name = "dids", IsRequired = false)]
        public IEnumerable<string>? DIDs { get; set; }

        /// <inheritdoc cref="ICallSearchParameters.Billed"/>
        /// <example><code>false</code></example>
        public bool Billed { get; set; }

        /// <inheritdoc cref="ICallSearchParameters.Answered"/>
        /// <example><code>false</code></example>
        public bool Answered { get; set; }

        /// <inheritdoc cref="ICallSearchParameters.Limit"/>
        /// <example><code>0</code></example>
        public int Limit { get; set; }

        /// <inheritdoc cref="ICallSearchParameters.MaxRecords"/>
        /// <example><code>0</code></example>
        public uint MaxRecords { get; set; }

        /// <inheritdoc cref="ICallSearchParameters.Protocol"/>
        public string? Protocol { get; set; }

        /// <inheritdoc cref="ICallSearchParameters.Filter"/>
        public string? Filter { get; set; }

        /// <inheritdoc cref="ICallSearchParameters.Tags"/>
        [DataMember(Name = "tags", IsRequired = false)]
        public IEnumerable<string>? Tags { get; set; }

        /// <inheritdoc cref="ICallSearchParameters.TimeOut"/>
        [DataMember(Name = "timeout", IsRequired = false)]
        public TimeSpan? TimeOut { get; set; }
    }
}
