using Sufficit.Telefonia.Asterisk;
using Sufficit.Telephony;
using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace Sufficit.Telefonia
{
    [Serializable]
    public class Extensao : ExtensaoBase, IExtension
    {
        #region IMPLEMENT INTERFACE EXTENSION

        Guid IExtension.IDContext => IDContexto;

        string IExtension.Description => Descricao;

        #endregion

        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingDefault)]
        public Guid IDMembro { get; set; }

        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingDefault)]
        public bool Encaminhamento { get; set; }

        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingDefault)]
        public bool Gravacao { get; set; }

        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingDefault)]
        public TDispositivo[] Tecnologia { get; set; }

        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public string? Senha { get; set; }

        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public string? FreePBX { get; set; }

        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public string? Ambiente => GetFreePBX();

        [JsonIgnore]
        public IIndexable? Provider { get; set; }

        public void setAmbiente(string ambiente)
        {
            FreePBX = ambiente;
        }

        #region CONSTRUTORES

        public Extensao() {
            Tecnologia = Array.Empty<TDispositivo>();
        }

        public Extensao(string Titulo) : this()
        {
            this.Titulo = Titulo;
        }

        #endregion
        #region  OVERRIDES & IMPLICIT

        public static implicit operator Extensao?(string? title)
        {
            Extensao? item = null;
            if (!string.IsNullOrWhiteSpace(title))
            {
                // VERIFICANDO MODO (DIAL)
                if (title!.Contains("/"))
                {
                    item = new Extensao();
                    var titulo = title.Split('/')[1];
                    if (titulo.Contains("@"))
                    {
                        titulo = titulo.Split('@')[0];
                        item.setAmbiente(title.Split('@')[1]);
                    }
                    if (title.Contains(","))
                    {
                        int prio;
                        if (int.TryParse(title.Split(',')[1], out prio)) item.Prioridade = prio.ToString();
                    }
                    item.Titulo = titulo;
                }
                else if (title.Contains(","))
                {
                    string[] titulo = title.Split(',');
                    if (titulo.Length == 3)
                    {
                        item = new Extensao(title.Split(',')[1]);
                        item.setAmbiente(title.Split(',')[0]);
                        item.Prioridade = title.Split(',')[2];
                    }
                }

                if (item == null) { item = new Extensao(title); }
            }

            return item;
        }

        public override int GetHashCode()
        {
            int hash = 0;
            if (Titulo != null) hash += Titulo.GetHashCode();
            if (Descricao != null) hash += Descricao.GetHashCode();
            if (IDContexto != Guid.Empty) hash += IDContexto.GetHashCode();
            return hash;
        }

        #endregion

        /// <summary>
        /// DAR UM JEITO NISSO
        /// </summary>
        /// <returns></returns>
        protected string? GetFreePBX()
        {
            if (string.IsNullOrWhiteSpace(FreePBX))
            {
                if (!string.IsNullOrWhiteSpace(Apelido) && Apelido.Extensao.Length >= 6)
                    FreePBX = Apelido.Extensao.Substring(0, 6);
                else if (!string.IsNullOrEmpty(Titulo) && Titulo.StartsWith("00") && Titulo.Length >= 6)
                    FreePBX = Titulo.Substring(0, 6);
                else if (IDContexto != Guid.Empty)                
                    throw new Exception("freepbx context not found");                
            }
            return FreePBX;
        }

        #region CONFIGURAÇÕES EXTRAS

        /// <summary>
        /// Configuração de codecs deste ramal / extensão / dispositivo <br />
        /// Para o FreePBX fica em Dispositivos
        /// </summary>
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingDefault)]
        public AsteriskCodecConfiguration Codecs { get; } = new AsteriskCodecConfiguration();

        /// <summary>
        /// Telefone que deverá ser binado ao cliente final em chamadas de saída
        /// </summary>
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public string? OutBoundCallerId { get; set; }

        #endregion
    }
}
