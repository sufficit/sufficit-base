﻿using Sufficit.EntityFramework;
using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace Sufficit.Telefonia.Asterisk
{
    /// <summary>
    /// Informação vinda de Asterisk CDR <br/>ø
    /// Normalmente cada canal de uma chamada telefonica é divido pela uniqueid <br/>
    /// Cada chamada telefonica é agrupada pela linkedid
    /// </summary>
    public class AsteriskCallDetailsRecord
    {
        #region CHAVE PRIMARIA

        /// <summary>
        /// Momento em iniciou o canal dentro do servidor
        /// </summary>
        [DateTimeKind(DateTimeKind.Utc)]
        public DateTime start { get; set; }

        /// <summary>
        /// Número auto incrementado por cada servidor indicando a tarefa do serviço do asterisk desde que foi iniciado ou reiniciado<br />
        /// Ou seja sequência de processamento do canal dentro de cada servidor
        /// </summary>
        [StringLength(11), DefaultValue(0)]
        public int sequence { get; set; }

        /// <summary>
        /// TAG do servidor que processou este canal
        /// </summary>
        [StringLength(10), DefaultValue("")]
        public string server { get; set; }

        #endregion

        #region INDICES

        [DataType("CHAR(36)"), StringLength(36), DefaultValue("")]
        public string suffidcliente { get; set; }

        [DefaultValue("")]
        public string did { get; set; }

        [DefaultValue("")]
        public string dst { get; set; }

        [DefaultValue(0)]
        public int amaflags { get; set; }

        #endregion

        /// <summary>
        /// Momento em que o canal foi atendido
        /// </summary>
        [DateTimeKind(DateTimeKind.Utc)]
        public DateTime answer { get; set; }

        /// <summary>
        /// Momento de término do canal
        /// </summary>
        [DateTimeKind(DateTimeKind.Utc)]
        public DateTime end { get; set; }

        /// <summary>
        /// Titulo de quem iniciou a chamada
        /// </summary>
        [StringLength(80), DefaultValue("")]
        public string clid { get; set; }

        /// <summary>
        /// Fonte do canal
        /// </summary>
        [StringLength(80), DefaultValue("")]
        public string src { get; set; }

        /// <summary>
        /// Contexto de destino do canal
        /// </summary>
        [StringLength(80), DefaultValue("")]
        public string dcontext { get; set; }

        /// <summary>
        /// Titulo deste canal
        /// </summary>
        [StringLength(80), DefaultValue("")]
        public string channel { get; set; }

        /// <summary>
        /// Canal de destino
        /// </summary>
        [StringLength(80), DefaultValue("")]
        public string dstchannel { get; set; }

        /// <summary>
        /// Ultima aplicação executada neste canal
        /// </summary>
        [StringLength(80), DefaultValue("")]
        public string lastapp { get; set; }

        /// <summary>
        /// Argumentos utilizados pela ultima aplicação
        /// </summary>
        [StringLength(80), DefaultValue("")]
        public string lastdata { get; set; }

        /// <summary>
        /// Tempo de chamada total, desde o momento que foi recebido pelo servidor
        /// </summary>
        [StringLength(11), DefaultValue(0)]
        public int duration { get; set; }

        /// <summary>
        /// Tempo de tarifação
        /// </summary>
        [StringLength(11), DefaultValue(0)]
        public int billsec { get; set; }

        /// <summary>
        /// Estado do canal (Atendido ou outra coisa)
        /// </summary>
        [StringLength(45), DefaultValue("")]
        public string disposition { get; set; }

        /// <summary>
        /// Código de conta do cliente
        /// <br /> (ESCRITA) Permite alteração manual
        /// </summary>
        [StringLength(32), DefaultValue("")]
        public string accountcode { get; set; }

        /// <summary>
        /// Id do canal de voz, normalmente um timestamp (ex: 3424323423.83243) ou com algum prefixo de texto (ex: teste-3424323423.83243)<br />
        /// Nem sempre é somente número
        /// </summary>
        [StringLength(32), DefaultValue("")]
        public string uniqueid { get; set; }

        /// <summary>
        /// Campo personalizavel pelo usuário, use como quizer 
        /// <br /> (ESCRITA) Permite alteração manual
        /// </summary>
        [StringLength(255), DefaultValue("")]
        public string userfield { get; set; }

        /// <summary>
        /// Nome do arquivo de gravação do canal 
        /// </summary>
        [StringLength(255), DefaultValue("")]
        public string recordingfile { get; set; }

        /// <summary>
        /// Número de quem ligou, de quem iniciou a chamada (ex: +55 21 32131232) 
        /// </summary>
        [StringLength(80), DefaultValue("")]
        public string cnum { get; set; }

        /// <summary>
        /// Titulo de quem ligou, de quem iniciou a chamada (ex: FULANO DA SILVA) 
        /// </summary>
        [StringLength(80), DefaultValue("")]
        public string cnam { get; set; }

        /// <summary>
        /// Número (BINA) que deve aparecer para o destino, NÃO UTILIZADO AINDA, não suportado por nenhuma operadora 
        /// </summary>
        [StringLength(80), DefaultValue("")]
        public string outbound_cnum { get; set; }


        /// <summary>
        /// Titulo que deve aparecer para o destino, NÃO UTILIZADO AINDA, não suportado por nenhuma operadora 
        /// </summary>
        [StringLength(80), DefaultValue("")]
        public string outbound_cnam { get; set; }

        /// <summary>
        /// Titulo que deve aparecer para o destino, NÃO UTILIZADO AINDA, não suportado por nenhuma operadora 
        /// </summary>
        [StringLength(80), DefaultValue("")]
        public string dst_cnam { get; set; }

        /// <summary>
        /// Protocolo da chamada, id que iniciou todas as conexões futuras lincadas a ele
        /// </summary>
        [StringLength(32), DefaultValue("")]
        public string linkedid { get; set; }

        /// <summary>
        /// Código de conta do tronco, NÃO UTILIZADO AINDA
        /// </summary>
        [StringLength(80), DefaultValue("")]
        public string peeraccount { get; set; }
    }
}
