using System.Text.Json.Serialization;

namespace Sufficit.Telefonia
{
    public class Identificacao
    {
        /// <summary>
        /// Nome a ser exibido
        /// </summary>        
        public string Titulo
        {
            get
            {
                return _titulo;
            }
            set
            {
                if (!string.IsNullOrWhiteSpace(value))
                {
                    _titulo = value.Replace("\"", "");
                }
            }
        }
        private string _titulo = string.Empty;

        /// <summary>
        /// Extensão a ser exibida
        /// </summary>
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingDefault)]
        public string Extensao { get; set; } = string.Empty;

        #region CONSTRUTORES

        public Identificacao(string obj)
        {
            if (!string.IsNullOrWhiteSpace(obj))
            {
                string texto = obj;
                int iSmaller = texto.IndexOf('<');
                if (iSmaller > -1)
                {
                    int iBigger = texto.IndexOf('>');
                    if (iBigger > -1 && iBigger > iSmaller)
                    {
                        Extensao = texto.Substring(iSmaller + 1, iBigger - iSmaller - 1);
                        Extensao = Extensao.Trim();

                        texto = texto.Remove(iSmaller, iBigger - iSmaller);
                    }
                }
                texto = texto.Trim();
                Titulo = texto.Replace("\"", "");
            }
        }

        public Identificacao() { }

        #endregion

        #region OVERRIDES & IMPLICIT

        public override string ToString()
        {
            string resultado = string.Empty;
            if (!string.IsNullOrWhiteSpace(Titulo))
                resultado += $"\"{ Titulo }\" ";

            if (!string.IsNullOrWhiteSpace(Extensao))
                resultado += $"<{ Extensao }>";
            return resultado;
        }

        public override int GetHashCode()
        {
            int hash = Titulo.GetHashCode();
            hash += Extensao.GetHashCode();
            return hash;
        }

        public override bool Equals(object? obj)
        {
            return base.Equals(obj);
        }

        public static implicit operator string(Identificacao obj)
        {
            if (obj != null)
                return obj.ToString();
            return string.Empty;
        }

        public static implicit operator Identificacao(string obj)
        {
            return new Identificacao(obj);
        }

        #endregion
    }
}
