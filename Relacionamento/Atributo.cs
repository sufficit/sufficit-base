using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sufficit.Relacionamento
{
    public class Atributo
    {
        public string Titulo { get; set; }
        public string Valor { get; set; }
        public string Descricao { get; set; }

        public Atributo() {
            this.Titulo = this.Valor = this.Descricao = string.Empty;
        }

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
                    if (this.Titulo.ToLowerInvariant().Trim() == ((Atributo)obj).Titulo.ToLowerInvariant().Trim())
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