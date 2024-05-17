using Sufficit.Contacts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json.Serialization;
using static Sufficit.Contacts.Constants;

namespace Sufficit.Relacionamento
{
    public class Contato : Contact, IContato, IIndexavel
    {
        #region IMPLEMENTAÇÃO IINDEXAVEL

        Guid IIndexavel.ID => this.Id;

        string IIndexavel.Descricao => this.Referencia;


        #endregion
        #region IMPLEMENTAÇÃO ICONTATO

        Guid IContato.ID => this.Id;

        #endregion
        #region PROPRIEDADES

        /// <summary>
        /// Propriedades diversas de um contato
        /// </summary>
        [JsonIgnore]
        public virtual IEnumerable<Atributo> Atributos { get; protected set; }

        #region PROPRIDADES FACILITADORAS

        /// <summary>
        /// Idenficador exclusivo do proprietário deste contato
        /// </summary>/// <remarks>Tipo de dados GUID uniqueidentifier</remarks>
        /// <value>Guid.NewGuid()</value>
        public virtual Guid IDProprietario { get; set; }

        /// <summary>
        /// Nome para exibição do Contato
        /// </summary>
        public string Titulo
        {
            get { return Title ?? UNTITLED; }
            set { Title = value; }
        }

        /// <summary>
        /// Data / Hora do momento em que foi registrado o contato
        /// </summary>
        /// <value>DateTime.Now()</value>
        public virtual DateTime Cadastro { get; set; }

        /// <summary>
        /// Data / Hora da ultima atualização
        /// </summary>
        public DateTime Atualizacao
        {
            get { return Update; }
            set { Update = value; }
        }

        #region DEPRECIADO

        /// <summary>
        /// Retorna o primeiro Telefone válido encontrado na lista de atributos
        /// </summary>
        public virtual string Telefone { get { return Atributo(TAtributo.Telefone); } }

        /// <summary>
        /// Retorna o primeiro E-Mail válido encontrado na lista de atributos
        /// </summary>
        public virtual string EMail { get { return Atributo(TAtributo.EMail); } }

        /// <summary>
        /// Texto contendo o primeiro meio de comunicação disponível deste contato, sendo telefone ou e-mail.
        /// </summary>
        /// <value>String.Empty</value>
        public virtual string Referencia
        {
            get
            {
                string resultado = Atributo(TAtributo.Telefone);
                if(string.IsNullOrWhiteSpace(resultado)) resultado = Atributo(TAtributo.EMail);
                return resultado;
            }
        }

        #endregion

        #endregion

        #endregion
        #region CONSTRUTORES

        public Contato(Guid id, IEnumerable<Atributo> atts)
        {
            this.Id = id;

            if (atts != null) this.Atributos = atts;
            else this.Atributos = new List<Atributo>();           
        }

        /// <summary>
        /// Construtor que inicia gerando o GUID ID único
        /// </summary>
        /// <param name="ID">GUID ID Único para identificacão do Contato independente do contexto</param>
        /// <param name="Titulo">Nome dado para exibição do Contato</param>
        public Contato(Guid ID, string Titulo) : this(ID, new List<Atributo>())
        {
            this.Title = Titulo;
        }

        #endregion
        #region OVERRIDES / IMPLICITS

        public override string ToString()
            => Titulo;

        public override bool Equals(object? obj)
        {
            if (obj != null && obj is Contato contact)
                if (contact.Id == this.Id) return true;
            return this.GetHashCode() == obj?.GetHashCode();
        }

        public override int GetHashCode()
        {
            return this.Id.GetHashCode();
        }

        public static implicit operator string(Contato obj)
        {
            if (obj != null)
                return obj.ToString();

            return UNTITLED;
        }

        #endregion
        #region METODOS


        /// <summary>
        /// Retorna o valor do primeiro atributo encontrado com a chave específicada
        /// </summary>
        /// <param name="Chave"></param>
        /// <returns></returns>
        public virtual string Atributo(string Chave)
        {
            string resultado = string.Empty;
            string chave = Chave.ToLowerInvariant().Trim();
            if (Atributos != null) {
                var item = Atributos.FirstOrDefault(subitem => subitem.Titulo.Equals(chave));
                if (item != null) resultado = item.Valor;
            }
            return resultado;
        }

        /// <summary>
        /// Retorna o valor do primeiro atributo encontrado com o tipo de chave específicada
        /// </summary>
        public virtual string Atributo(TAtributo Tipo)
        {
            string resultado = string.Empty;

            foreach (Atributo item in Atributos)
            {
                if(Sufficit.Relacionamento.Atributo.Tipo(item.Titulo) == Tipo)
                {
                    if (!string.IsNullOrWhiteSpace(item.Valor))
                    {
                        if (Tipo == TAtributo.Telefone)
                        {
                            resultado = System.Text.RegularExpressions.Regex.Replace(item.Valor, @"[^\d]", "");
                        }
                        else
                        {
                            resultado = item.Valor.Trim();
                        }
                        break;
                    }
                }                
            }

            return resultado;
        }

        #endregion

        #region DEPRECIADO

        /// <summary>
        /// Marcado para remoção
        /// Utilize IDProprietario
        /// </summary>
        [Obsolete("Use .IDProprietario instead !")]
        public Guid IDMembro => IDProprietario;

        [Obsolete("Use .Id instead !")]
        public Guid ID { get => Id; set => Id = value; }

        #endregion
    }
}
