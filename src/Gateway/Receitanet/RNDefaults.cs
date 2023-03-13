using System;
using System.Collections.Generic;
using System.Text;

namespace Sufficit.Gateway.ReceitaNet
{
    /// <summary>
    /// Saidas padrões para cada cliente
    /// </summary>
    public class RNDefaults
    {
        /// <summary>
         /// <para>Chamada encerrada com sucesso</para>
         /// <para>Atendimento concluído e cliente satisfeito</para>
         /// </summary>
         /// <value>app-blackhole,hangup,1 //Valor padrão do FreePBX</value>
        public string Hangup { get; set; } = string.Empty;

        /// <summary>
        /// <para>Saída usada quando este script esta offline</para>
        /// <para>Meramente ilustrativo aqui nesta seção</para>
        /// </summary>
        public string Offline { get; set; } = string.Empty;

        /// <summary>
        /// Saída usada caso o sistema apresente qualquer tipo de falha
        /// </summary>
        public string Fail { get; set; } = string.Empty;

        /// <summary>
        /// <para>Saída usada caso o cliente foi identificado e por algum motivo solicitou ser atendido por uma pessoa</para>
        /// <para>Normalmente tecla 9</para>
        /// </summary>
        public string Solicited { get; set; } = string.Empty;

        /// <summary>
        /// Saída usada quando o chamador não é cliente ou não conseguiu se identificar
        /// </summary>
        public string Unknown { get; set; } = string.Empty;

        /// <summary>
        /// <para>Saída usada caso o cliente foi identificado e está conectado</para>
        /// <para>Outros assuntos ou provável instabilidade na conexão</para>
        /// </summary>
        public string Connected { get; set; } = string.Empty;
    }
}
