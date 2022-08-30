using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;
using System.Text.Json.Serialization;

namespace Sufficit.Telephony
{
    /// <summary>
    /// DID = Linha de entrada no sistema de telefonia
    /// </summary>
    public class DirectInwardDialingV1 : IDirectInwardDialing, IIndexable
    {
        [Key]
        [JsonPropertyName("extension")]
        public string Extension { get; set; } = default!;

        [JsonPropertyName("id")]
        public Guid Id { get; set; }

        [JsonPropertyName("provider")]
        public Guid ProviderId { get; set; }

        [JsonPropertyName("context")]
        public Guid ContextId { get; set; }

        [JsonPropertyName("billed")]
        public bool Billed { get; set; }



        public DateTime cadastro { get; set; }
        public string descricao { get; set; } = default!;
        public string tdestino { get; set; } = default!;
        public string origem { get; set; } = default!;
        public string tags { get; set; } = default!;
        public string dstclasse { get; set; } = default!;
        public string dstid { get; set; } = default!;

        #region IMPLEMENTING INTERFACE DIRECT INWARD DIALING

        Guid IDirectInwardDialing.ID => Id;
        string IDirectInwardDialing.Dialing => Extension;

        #endregion

        #region IMPLEMENTING INTERFACE INDEXABLE

        Guid IIndex.Id => Id;
        Guid IIndexable.ContextId => ContextId;
        string IIndexable.Title => Extension;
        string IIndexable.Description => descricao;

        #endregion
    }
}
