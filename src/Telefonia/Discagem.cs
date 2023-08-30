using System;
using System.Linq;

namespace Sufficit.Telefonia
{
    public class Discagem : IDiscagem
    {
        public Discagem() { }

        public Discagem(string obj)
        {
            if (!string.IsNullOrWhiteSpace(obj))
            {
                if (obj.Contains("+"))
                {
                    Precedencia = obj.Split('+')[0];
                    obj = obj.Remove(0, obj.IndexOf('+') + 1);
                }
                if (obj.Contains("|"))
                {
                    Prefixo = obj.Split('|')[0];
                    obj = obj.Remove(0, obj.IndexOf('|') + 1);
                }
                if (obj.Contains('/'))
                {
                    Origem = obj.Split('/')[1];
                    obj = obj.Remove(obj.IndexOf('/'));
                }

                Padrao = obj;
            }
        }

        public string Titulo { get; set; } = string.Empty;
        public string Precedencia { get; set; } = string.Empty;
        public string Prefixo { get; set; } = string.Empty;
        public string Padrao { get; set; } = string.Empty;
        public string Origem { get; set; } = string.Empty;

        public override bool Equals(object obj)
        {
            return this.GetHashCode() == obj.GetHashCode();
        }

        public override int GetHashCode()
        {
            int retorno = 0;
            if (!string.IsNullOrWhiteSpace(Precedencia)) { retorno += Precedencia!.GetHashCode(); }
            if (!string.IsNullOrWhiteSpace(Prefixo)) { retorno += Prefixo!.GetHashCode(); }
            if (!string.IsNullOrWhiteSpace(Padrao)) { retorno += Padrao!.GetHashCode(); }
            if (!string.IsNullOrWhiteSpace(Origem)) { retorno += Origem!.GetHashCode(); }
            return retorno;
        }
        public override string ToString()
        {
            return (string)this;
        }

        public static implicit operator Discagem(string obj)
        {
            return new Discagem(obj);
        }

        public static implicit operator string(Discagem obj)
        {
            if (obj != null)
            {
                string item = String.Empty;
                if (!string.IsNullOrWhiteSpace(obj.Padrao))
                {
                    item = obj.Padrao;
                    if (!string.IsNullOrWhiteSpace(obj.Prefixo)) { item = item.Insert(0, obj.Prefixo + "|"); }
                    if (!string.IsNullOrWhiteSpace(obj.Precedencia)) { item = item.Insert(0, obj.Precedencia + "+"); }
                    if (!string.IsNullOrWhiteSpace(obj.Origem)) { item = item + "/" + obj.Origem; }
                    return item;
                }
            }
            return string.Empty;
        }

        #region FACILITADORES TEMPORARIOS

        public string Rota { get; set; } = string.Empty;

        #endregion        
    }
}
