using Sufficit.Contacts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace Sufficit.Relacionamento
{   
    public class Atributo : IAttribute
    {
        #region IMPLEMENT INTERFACE ATTRIBUTE

        string IAttribute.Key => this.Key;

        #endregion

        public NormalizedString Key { get; set; }

        public string Value { get; set; } = default!;

        public string Description { get; set; } = default!;

        [JsonIgnore]
        public string Titulo { get { return Key; } set { Key = value; } }

        [JsonIgnore]
        public string Valor { get { return Value ?? string.Empty; } set{ Value = value; } }

        [JsonIgnore]
        public string Descricao { get { return Description ?? string.Empty; } set { Description = value; } }


        public Atributo() { }

        public Atributo(string key, string value, string description)
        {
            Key = key;
            Value = value;
            Description = description;
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

        public override bool Equals(object? obj)
        {
            bool resultado = false;
            if (obj != null) 
            {
                if (obj is Atributo) 
                {
                    if (this.Key.Equals(((Atributo)obj).Key))
                    {
                        if (this.Value.Trim() == ((Atributo)obj).Value.Trim())
                        {
                            if (this.Description.Trim() == ((Atributo)obj).Description.Trim()) 
                                resultado = true;
                        }
                    }
                }
            }
            return resultado;
        }

        public override int GetHashCode()
            => (Key, Value, Description).GetHashCode();        

        #endregion
    }

}