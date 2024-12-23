﻿using Sufficit.Telefonia.Tempo;
using Sufficit.Telephony;
using Sufficit.Telephony.FreePBX;
using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Linq;
using System.Text.Json.Serialization;

namespace Sufficit.Telefonia
{
    public class CondicaoTempo : Destino, IDestination, IFriendly
    {
        public const string FREEPBXCONTEXT = "timeconditions";
        public const string FRIENDLYNAME = Sufficit.Telephony.TimeCondition.FRIENDLYNAME;

        #region IMPLEMENT INTERFACE IFRIENDLY

        string IFriendly.ToFriendly() => FRIENDLYNAME;

        #endregion
        #region IMPLEMENT INTERFACE IDESTINATION

        Guid? IDestination.Id => this.ID;

        string IDestination.TypeName => nameof(CondicaoTempo);

        Guid? IDestination.ContextId => this.IDContexto;

        string IDestination.Asterisk => this.Asterisk;

        string? IDestination.Title => this.Titulo;

        string? IDestination.Description => !string.IsNullOrWhiteSpace(Descricao) ? Descricao : null;

        #endregion
        #region IMPLEMENTACAO DESTINO

        public override string Titulo { get; set; } = default!;
        public override string Descricao { get; set; } = string.Empty;
        public override string Categoria => FRIENDLYNAME;
        public static string ToAmigavel() => FRIENDLYNAME;

        #endregion
        #region IMPLEMENTAÇÃO OLD DESTINO

        [JsonIgnore]
        public override Type Classe => this.GetType();

        #endregion

        public Dictionary<bool, Destino> Destinos { get; } = new Dictionary<bool, Destino>();

        public HashSet<Intervalo> Intervalos { get; set; } = new HashSet<Intervalo>();

        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingDefault)]
        public Extensao DestinoFalso { get; set; } = default!;

        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingDefault)]
        public Extensao DestinoVerdadeiro { get; set; } = default!;
        
        [JsonIgnore]
        public IIndexable? Provider { get; set; }

        /// <summary>
        /// Timezone
        /// </summary>        
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingDefault)]
        public string Local { get; set; } = string.Empty;

        [JsonPropertyName("fpbxid")]
        public int FPBXid { get; set; } = -1;

        [JsonPropertyName("fpbxtime")]
        public int FPBXtime { get; set; } = -1;
    }
}
