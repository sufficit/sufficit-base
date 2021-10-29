using System;
using System.Collections.Generic;
using System.Text;

namespace Sufficit.Telephony.RealTime
{
    public class RTCallQueue
    {
        public Guid ID { get; set; }
        public Guid IDContexto { get; set; }
        public string Titulo { get; set; }
        public int Tempo { get; set; }
        public int Anuncio { get; set; }
        public string Destino { get; set; }
        public string Espera { get; set; }
        public string Agentes { get; set; }
        public bool Ativo { get; set; }
        public string Descricao { get; set; }
        public string Estrategia { get; set; }
        public bool Toque { get; set; }
        public string DSTClasse { get; set; }
        public Guid DSTId { get; set; }
        public Guid IDSopro { get; set; }
        public bool Restrito { get; set; }
        public bool Reinicio { get; set; }
        public int ATempo { get; set; }
        public int TTentativas { get; set; }
        public int TIntervalo { get; set; }
    }
}
