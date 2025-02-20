﻿using System;
using System.Collections.Generic;
using System.Globalization;
using System.Text;

namespace Sufficit.Telephony
{
    /// <summary>
    /// Telephony calls queue
    /// </summary>
    public class CallQueue : IDestination, IFriendly
    {
        public const string FREEPBXCONTEXT = Sufficit.Telefonia.FilaEspera.FREEPBXCONTEXT;
        public const string FRIENDLYNAME = Sufficit.Telefonia.FilaEspera.FRIENDLYNAME;

        #region IMPLEMENT INTERFACE IFRIENDLY

        string IFriendly.ToFriendly() => FRIENDLYNAME;

        #endregion
        #region IMPLEMENTING INTERFACE IDESTINATION

        Guid? IDestination.Id => Id;

        string IDestination.TypeName => nameof(CallQueue);

        Guid? IDestination.ContextId => ContextId;

        string IDestination.Asterisk => $"{FREEPBXCONTEXT},{Extension},1";

        string? IDestination.Title => Title;

        string? IDestination.Description => null;

        #endregion
        #region BASIC PROPERTIES

        /// <summary>
        /// Unique identifier of this object
        /// </summary>
        public Guid Id { get; set; }

        /// <summary>
        /// Context | Client unique identifier
        /// </summary>
        public Guid ContextId { get; set; }

        public string Title { get; set; } = "Untitled";

        /// <summary>
        /// Current Asterisk extension
        /// </summary>
        public string? Extension { get; set; }

        #endregion

        public string Agents { get; set; } = default!;

        /// <summary>
        ///     Max wait time in seconds
        /// </summary>
        public uint WaitTime { get; set; }

        /// <summary>
        ///     Destination in Asterisk GoTo format
        /// </summary>
        public string Destination { get; set; } = default!;

        /*
        #region TIME OPTIONS

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


        */
    }
}
