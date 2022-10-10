using System;
using System.Diagnostics;

namespace Sufficit.Log
{
    public class Evento
    {
        public Guid IDMembro { get; set; }
        public Guid IDContexto { get; set; }
        public Type Classe { get; set; } 
        public string Descricao { get; set; }
        public string? Origem { get; set; }

        /// <summary>
        /// JSON com todas as informações do objeto que foi atualizado
        /// </summary>
        public string? Objeto { get; set; }

        /// <summary>
        /// Data/Hora de inicio do evento 
        /// </summary>
        public DateTime Cadastro { get; set; }

        /// <summary>
        /// Data/Hora em que deixa de ser importante e se torna obsoleto
        /// </summary>
        public DateTime Validade { get; set; }

        public long Duracao { get; set; }

        public Evento(Type Classe, string Descricao, Guid IDContexto) : this()
        {
            this.IDContexto = IDContexto;
            this.Classe = Classe;
            this.Descricao = Descricao;
        }

        public Evento(Type Classe, string Descricao, Guid IDContexto, Stopwatch Duracao) : this(Classe, Descricao, IDContexto)
        {
            this.Duracao = Duracao.ElapsedMilliseconds;
        }

        public Evento(string? Descricao = null, Type? Classe = null, Guid? IDContexto = null, Stopwatch? Duracao = null)
        {
            this.Cadastro = DateTime.Now;
            this.Validade = DateTime.Now.AddMonths(6);

            this.IDContexto = IDContexto ?? Guid.Empty;
            this.Classe = Classe ?? this.GetType();
            this.Descricao = Descricao ?? string.Empty;
            this.Duracao = Duracao?.ElapsedMilliseconds ?? 0;
        }


        #region OVERRIDES & IMPLICIT

        public override string ToString()
        {
            string item = Cadastro.ToString("yyyy/MM/dd HH:mm:ss.fff");
            item += " :: ";
            item += IDContexto.ToString("N");
            item += " :: ";
            item += Descricao ?? "evento desconhecido";
            if (Classe != null)
            {
                item += " :: ";
                item += String.Concat("(", Classe.ToString(),")");
            }
            if (!String.IsNullOrWhiteSpace(Origem))
            {
                item += " :: ";
                item += String.Concat("[", Origem, "]");
            }

            item += " :: ";
            item += String.Concat("duração: {", Duracao, "}");
            return item;
        }

        public static implicit operator string (Evento obj)
        {
            return obj.ToString();
        }

        public static implicit operator Evento(string obj)
        {
            return new Evento(obj);
        }

        #endregion
    }
}
