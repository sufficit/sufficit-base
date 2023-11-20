using Sufficit.Telefonia.Tempo;
using Sufficit.Telephony;
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
        public const string FRIENDLYNAME = "Horário";

        #region IMPLEMENT INTERFACE IFRIENDLY

        string IFriendly.ToFriendly() => FRIENDLYNAME;

        #endregion
        #region IMPLEMENT INTERFACE IDESTINATION

        Guid? IDestination.Id => this.ID;

        string IDestination.TypeName => this.GetType().Name;

        Guid? IDestination.ContextId => this.IDContexto;

        string IDestination.Asterisk => this.Asterisk;

        string? IDestination.Title => this.Titulo;

        string? IDestination.Description => this.Descricao;

        #endregion
        #region IMPLEMENTACAO DESTINO

        public override string Titulo { get; set; } = default!;
        public override string Descricao { get; set; } = string.Empty;
        public override string Categoria => ToAmigavel();
        public static string ToAmigavel() => FRIENDLYNAME;

        #endregion
        #region IMPLEMENTAÇÃO OLD DESTINO

        public override Type Classe => this.GetType();

        #endregion

        public Dictionary<bool, Destino> Destinos { get; } = new Dictionary<bool, Destino>();

        public List<IntervaloBase> Intervalos { get; set; } = new List<IntervaloBase>();

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

        public int FPBXid { get; set; } = -1;

        public int FPBXtime { get; set; } = -1;
    }
}
