using Sufficit.Telephony;
using System;
using System.Collections.Generic;

namespace Sufficit.Telefonia
{
    public class FilaEspera : Destino, IDestino, IDestination, IFriendly
    {
        public const string FREEPBXCONTEXT = "ext-queues";
        public const string FRIENDLYNAME = "Fila de Espera";

        #region IMPLEMENT INTERFACE IFRIENDLY

        string IFriendly.ToFriendly() => FRIENDLYNAME;

        #endregion
        #region IMPLEMENT INTERFACE IDESTINATION

        Guid? IDestination.Id => this.ID;

        string IDestination.TypeName => this.GetType().Name;

        Guid? IDestination.ContextId => this.IDContexto;

        string IDestination.Asterisk => this.Asterisk;

        string? IDestination.Title => this.Titulo;

        string? IDestination.Description => string.Empty;

        #endregion
        #region IMPLEMENTACAO DESTINO

        public static string ToAmigavel() => FRIENDLYNAME;

        #endregion
        #region OPCOES DE TEMPO

        /// <summary>
        /// ( segundos ) Tempo de espera em segundos desta fila 
        /// </summary>
        public int Tempo { get; set; } = 80;

        /// <summary>
        /// <para>Se estiver ativo, quando o tempo máximo de espera for atingido, a chamada seguirá para o próximo destino.</para>
        /// <para>Se estiver inativo, aguardaremos a conclusão do agente atual, significa que o tempo total da fila será o tempo programado adicionado ao tempo que ainda falta deste agente.</para>
        /// </summary>
        public bool Restrito { get; set; } = true;

        /// <summary>
        /// <para>O tempo em segundos para tocar em cada agente antes de passarmos ao próximo da lista.</para>
        /// <para>Independente dos valores escolhidos, estes limite nunca ultrapassarão o tempo máximo de toque do ramal(específicado individualmente na tela de extensões) ou o tempo máximo de espera total desta fila.</para>
        /// </summary>
        public int ATempo { get; set; }

        /// <summary>
        /// <para>Se estiver habilitado, significa que a contagem de tempo indididual, irá reiniciar a cada sinal de OCUPADO ou SOBRECARREGADO.</para>
        /// <para>Ex: se o agente recusar a chamada ou estiver ocupado, o tempo não contará e não passará ao próximo a não ser que este ignore a chamada.</para>
        /// </summary>
        public bool AReinicio { get; set; } = false;

        /// <summary>
        /// <para>Tempo em segundos entre tentativas.</para>
        /// <para>0 não existe, mínimo 1 segundo</para>
        /// <para>The number of seconds we wait before trying all the phones again. Choosing "No Retry" will exit the Queue and go to the fail-over destination as soon as the first attempted agent times-out, additional agents will not be attempted.</para>
        /// </summary>
        public int TTentativas { get; set; } = 1;

        /// <summary>
        /// Tempo de intervalo entre chamadas bem sucedidas<br />
        /// After a successful call, how many seconds to wait before sending a potentially free agent another call (default is 0, or no delay) If using Asterisk 1.6+, you can also set the 'Honor Wrapup Time Across Queues' setting (Asterisk: shared_lastcall) on the Advanced Settings page so that this is honored across queues for members logged on to multiple queues.
        /// </summary>
        public int TIntervalo { get; set; } = 0;

        #endregion

        //public Guid IDContexto { get; set; }
        public int Codigo { get; set; }

        /// <summary>
        /// Depreciado, antigamente usado para bloquear clientes
        /// </summary>
        public int TempoPadrao { get; set; }
        public virtual int Anuncio { get; set; }
        public string Musica { get; set; } = "default";
        public List<Extensao> Agentes { get; set; } 
            = new List<Extensao>();
        public bool Ativo { get; set; }
        public string Estrategia { get; set; } = "ringall";
        public TChamado Chamado { get; set; } = TChamado.MusicaDeEspera;
        public string Toque { get; set; } = "espera";
        public Destino Destino { get; set; } 
            = default!;

        /// <summary>
        /// Guid do áudio usado para sopro
        /// </summary>
        /// <remarks>Mensagem para o Agente (pessoa que atende a uma ligação) dessa Fila de Espera ao atender o telefone, antes de falar com o cliente</remarks>
        public Guid IDSopro { get; set; }

        /// <summary>
        /// ID do áudio usado para sopro pelo FreePBX
        /// </summary>
        /// <remarks>Mensagem para o Agente (pessoa que atende a uma ligação) dessa Fila de Espera ao atender o telefone, antes de falar com o cliente</remarks>
        public int FPBXagentannounce_id { get; set; }

        #region FACILITADORES

        public string Extensao { get; set; }
            = string.Empty;

        #endregion

        public override bool Equals (object obj)
        {
            if (obj is FilaEspera)
                if (ID != Guid.Empty)
                    if (((FilaEspera)obj).ID == this.ID) return true;
            return base.Equals(obj);
        }

        public override int GetHashCode()
        {
            return base.GetHashCode();
        }
    }
}
