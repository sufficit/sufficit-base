using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sufficit.Relacionamento
{
    /// <summary>
    /// Substituição da String convencional
    /// Garante que esteja sempre em minusculo e sem espaços em branco nas laterais
    /// </summary>
    public class stringLower 
    {
        public string ToLowerInvariant() { return valor; }

        private string valor = string.Empty;

        public static implicit operator stringLower(string obj)
        {
            if (!string.IsNullOrWhiteSpace(obj))
                return new stringLower() { valor = obj.ToLowerInvariant().Trim() };
            else return new stringLower();
        }

        public static implicit operator string(stringLower obj)
        {
            if (obj != null) return obj.valor;
            else return string.Empty;
        }

        public override string ToString()
        {
            return valor;
        }

        public override bool Equals(object obj)
        {
            if(obj != null)            
                return obj.ToString().ToLowerInvariant().Trim() == valor;
            
            return base.Equals(obj);
        }

        public override int GetHashCode()
        {
            return base.GetHashCode();
        }
    }

    public class Atributo
    {
        string _value;
        string _description;

        public stringLower Titulo { get; set; }
        public string Valor { get { return _value ?? string.Empty; } set{ this._value = value; } }
        public string Descricao { get { return _description ?? string.Empty; } set { _description = value; } }

        public Atributo() { }

        public Atributo(string Titulo, string Valor, string Descricao)
        {
            this.Titulo = Titulo;
            this.Valor = Valor;
            this.Descricao = Descricao;
        }

        public static TAtributo Tipo(string Chave)
        {
            switch (Chave.Trim().ToLower())
            {
                case "cellular":        return TAtributo.Telefone;
                case "businessphone":   return TAtributo.Telefone;
                case "telefone":        return TAtributo.Telefone;
                case "email":           return TAtributo.EMail;
                default:                return TAtributo.Desconhecido;
            }
        }

        #region OVERRIDES 

        public override bool Equals(object obj)
        {
            bool resultado = false;
            if (obj != null) 
            {
                if (obj is Atributo) 
                {
                    if (this.Titulo.Equals(((Atributo)obj).Titulo))
                    {
                        if (this.Valor.Trim() == ((Atributo)obj).Valor.Trim())
                        {
                            if (this.Descricao.Trim() == ((Atributo)obj).Descricao.Trim()) resultado = true;
                        }
                    }
                }
            }
            return resultado;
        }

        public override int GetHashCode()
        {
            unchecked
            {
                int hash = 13;
                hash = (hash * 7) + this.Titulo.GetHashCode();
                hash = (hash * 7) + this.Valor.GetHashCode();
                hash = (hash * 7) + this.Descricao.GetHashCode();
                return hash;
            }
        }

        #endregion
    }

}