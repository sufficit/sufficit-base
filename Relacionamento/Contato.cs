using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Sufficit.Relacionamento
{
    [Serializable]
    public class Contato : IContato, IIndexavel
    {
        #region IMPLEMENTAÇÃO IINDEXAVEL

        string IIndexavel.Descricao => this.Referencia;

        #endregion
        #region IMPLEMENTAÇÃO ICONTATO

        // bool Grupo => throw new NotImplementedException();

        //public IEnumerable<Guid> IDGrupos { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }

        #endregion
        #region PROPRIEDADES

        /// <summary>
        /// Identificador exclusivo deste contato
        /// </summary>
        /// <remarks>Tipo de dados GUID uniqueidentifier</remarks>
        /// <value>Guid.NewGuid()</value>
        public Guid ID { get; internal set; }

        /// <summary>
        /// Propriedades diversas de um contato
        /// </summary>
        public virtual IEnumerable<Atributo> Atributos { get; protected set; }

        #region PROPRIDADES FACILITADORAS

        /// <summary>
        /// Idenficador exclusivo do proprietário deste contato
        /// </summary>/// <remarks>Tipo de dados GUID uniqueidentifier</remarks>
        /// <value>Guid.NewGuid()</value>
        public virtual Guid IDMembro { get; set; }
        
        /// <summary>
        /// Nome para exibição do Contato
        /// </summary>
        public virtual string Titulo { get; set; }
                
        /// <summary>
        /// Data / Hora do momento em que foi registrado o contato
        /// </summary>
        /// <value>DateTime.Now()</value>
        public virtual DateTime Cadastro { get; set; }
         
        /// <summary>
        /// Data / Hora da ultima atualização
        /// </summary>
        public virtual DateTime Atualizacao { get; set; }

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
            if (atts != null) Atributos = atts;
            else Atributos = new List<Atributo>();

            ID = id;
        }

        /// <summary>
        /// Construtor que inicia gerando o GUID ID único
        /// </summary>
        /// <param name="ID">GUID ID Único para identificacão do Contato independente do contexto</param>
        /// <param name="Titulo">Nome dado para exibição do Contato</param>
        public Contato(Guid ID, string Titulo) : this(ID, new List<Atributo>())
        {
            this.Titulo = Titulo;
        }

        #endregion
        #region OVERRIDES / IMPLICITS

        public override string ToString()
        {
            if (!String.IsNullOrWhiteSpace(Titulo))
                return Titulo;
            else return "Desconhecido";
        }

        public override bool Equals(object obj)
        {
            if (obj != null && obj is Contato)
                if (((Contato)obj).ID == this.ID) return true;
            return this.GetHashCode() == obj.GetHashCode();
        }

        public override int GetHashCode()
        {
            return this.ID.GetHashCode();
        }

        public static implicit operator string(Contato obj)
        {
            if (obj != null)
                return obj.ToString();

            return "Desconhecido";
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

            if(Atributos != null) {
                var item = Atributos.FirstOrDefault(subitem => subitem.Titulo == Chave);
                if (item != null) resultado = item.Valor;
            }

            return resultado;
        }

        /// <summary>
        /// Retorna o valor do primeiro atributo encontrado com o tipo de chave específicada
        /// </summary>
        /// <param name="Chave"></param>
        /// <returns></returns>
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
    }
}
