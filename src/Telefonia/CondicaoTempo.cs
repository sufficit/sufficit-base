using Sufficit.Telefonia.Tempo;
using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Linq;
using System.Text.Json.Serialization;

namespace Sufficit.Telefonia
{
    public class CondicaoTempo : Destino
    {
        #region IMPLEMENTACAO DESTINO

        public override string Titulo { get; set; } = default!;
        public override string Descricao { get; set; } = string.Empty;
        public override string Categoria => ToAmigavel();
        public static string ToAmigavel() { return "Horarios"; }

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
