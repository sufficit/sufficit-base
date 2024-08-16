using System;
using System.Linq;
using System.Text.Json.Serialization;
using Sufficit.Telephony;
using static Sufficit.Telephony.Constants;

namespace Sufficit.Telefonia
{
    public class Destino
    {
        public virtual string Titulo { get; set; }
        public virtual string Descricao { get; set; }
        public virtual string Categoria => GetCategory();

        [JsonPropertyName("typename")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull | JsonIgnoreCondition.WhenWritingDefault)]
        public string? TypeName => Classe?.Name;

        [JsonIgnore]
        public virtual Type? Classe { get; set; }

        [JsonPropertyName("id")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingDefault)]
        public virtual Guid ID { get; set; }

        /// <summary>
        /// Usado para indicar o cliente, na recuperação pela View de Destinos
        /// </summary>
        public virtual Guid IDContexto { get; set; }

        /// <summary>
        /// Destino no formato Asterisk GoTo (context,extension,priority)
        /// </summary>
        [JsonPropertyName("asterisk")]
        public virtual string Asterisk { get; set; } = string.Empty;

        private string GetCategory()
        {
            if (this is IFriendly friendly)            
                return friendly.ToFriendly();
            
            if (Classe != null)
            {
                if (Classe is IFriendly friendlyclass)
                    return friendlyclass.ToFriendly();

                string resultado = Classe.ToString();
                var metodo = Classe.GetMethod("ToAmigavel", System.Reflection.BindingFlags.Public | System.Reflection.BindingFlags.Static);
                if (metodo != null)
                {
                    var item = metodo.Invoke(null, null);
                    if (item != null && !string.IsNullOrWhiteSpace(item.ToString()))
                        resultado = item.ToString()!;
                }

                return resultado;
            }
            return UNKNOWNFRIENDLY;
        }

        #region CONSTRUTORES

        public Destino() {
            Titulo = string.Empty;
            Descricao = string.Empty;
        }

        public Destino(string item) : this()
        {
            if (!string.IsNullOrWhiteSpace(item))
            {
                Asterisk = item;
                if (Asterisk.Contains(','))
                {
                    string[] separado = Asterisk.Split(',');
                    if (separado.Length == 2)
                    {
                        Classe = Type.GetType(separado[0]);
                        ID = Guid.Parse(separado[1]);
                    }
                }
            }
        }

        #endregion
        #region FACILITADORES STRING

        public bool StartsWith(string item)
        {
            return Asterisk.StartsWith(item);
        }

        public bool Contains(string item)
        {
            return Asterisk.Contains(item);
        }

        public string[] Split(char itens)
        {
            return Asterisk.Split(itens);
        }

        #endregion
        #region OVERRIDES & IMPLICIT

        public override string ToString()
            => Asterisk ?? string.Empty;

        public static implicit operator string? (Destino? item)
            => item != null && !string.IsNullOrWhiteSpace(item.Asterisk) ? item.Asterisk : null;

        public static implicit operator Destino(string item)
            => new Destino(item);        

        #endregion
    }
}
