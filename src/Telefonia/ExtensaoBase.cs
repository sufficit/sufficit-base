using Sufficit.Telephony;
using System;
using System.Text.Json.Serialization;

namespace Sufficit.Telefonia
{
    [Serializable]
    public abstract class ExtensaoBase : IExtensao, IIndexavel
    {
        #region IMPLEMENTAÇÃO IINDEXAVEL

        public Guid ID { get; set; }

        public virtual string Titulo
        {
            get
            {
                if (!string.IsNullOrWhiteSpace(Apelido))
                    return Apelido.Extensao;
                else
                    return IDInterno.Extensao;
            }
            set { IDInterno.Extensao = value; }
        }

        public virtual string Descricao { get; set; } = string.Empty;

        #endregion

        /// <summary>
        /// Identificação Interna -> (CNAM - CNUM)
        /// </summary>
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingDefault)]
        public Identificacao IDInterno { get; set; } = new Identificacao();

        /// <summary>
        /// Identificação Externa -> (OUTBOUND_CNAM - OUTBOUND_CNUM)
        /// </summary>
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingDefault)]
        public Identificacao IDExterno { get; set; } = new Identificacao();

        /// <summary>
        /// Identificação alterar pela SUFFICIT 
        /// </summary>
        /// <remarks>aumentada com a ID do cliente</remarks>
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingDefault)]
        public Identificacao Apelido { get; set; } = new Identificacao();

        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingDefault)]
        public virtual Guid IDContexto { get; set; }

        public string TituloOriginal { get { return IDInterno.Extensao; } }

        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingDefault)]
        public int Qualificar { get; set; } = 2000;


        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingDefault)]
        public string Prioridade { get; set; } = string.Empty;

        #region OVERRIDES & IMPLICIT

        public override string ToString()
        {
            if (!string.IsNullOrWhiteSpace(Titulo))
                return Titulo;
            else return string.Empty;
        }

        public override int GetHashCode()
        {
            int hash = 0;
            if (Titulo != null) hash += Titulo.GetHashCode();
            if (Descricao != null) hash += Descricao.GetHashCode();
            if (IDContexto != Guid.Empty) hash += IDContexto.GetHashCode();
            return hash;
        }

        public override bool Equals(object? obj)
        {
            if (obj != null && !string.IsNullOrWhiteSpace(obj.ToString()))
                if (obj.ToString() == ToString())
                    return true;
            return base.Equals(obj);
        }

        public static implicit operator string(ExtensaoBase obj)
        {
            if (obj != null)
                return obj.ToString();

            return string.Empty;
        }

        #endregion
    }
}
