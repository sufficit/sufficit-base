using Sufficit.Telefonia.Asterisk;
using Sufficit.Telephony;
using System;
using System.Collections.Generic;

namespace Sufficit.Telefonia
{
    [Serializable]
    public class Extensao : ExtensaoBase, IExtension
    {
        #region IMPLEMENT INTERFACE EXTENSION

        Guid IExtension.IDContext => IDContexto;

        string IExtension.Description => Descricao;

        #endregion

        public Guid IDMembro { get; set; }
        public bool Encaminhamento { get; set; }
        public bool Gravacao { get; set; }

        public TDispositivo[] Tecnologia { get; set; }

        public string? Senha { get; set; }

        public string? FreePBX { get; set; }
        public string? Ambiente => GetFreePBX();

        protected IIndexable? _provedor;
        public IIndexable? getProvedor() { return _provedor; }
        public void setProvedor(IIndexable objeto) { _provedor = objeto; }

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

        public static implicit operator Extensao(string Titulo)
        {
            Extensao? item = null;
            if (!string.IsNullOrWhiteSpace(Titulo))
            {
                // VERIFICANDO MODO (DIAL)
                if (Titulo.Contains("/"))
                {
                    item = new Extensao();
                    var titulo = Titulo.Split('/')[1];
                    if (titulo.Contains("@"))
                    {
                        titulo = titulo.Split('@')[0];
                        item.setAmbiente(Titulo.Split('@')[1]);
                    }
                    if (Titulo.Contains(","))
                    {
                        int prio;
                        if (int.TryParse(Titulo.Split(',')[1], out prio)) item.Prioridade = prio.ToString();
                    }
                    item.Titulo = titulo;
                }
                else if (Titulo.Contains(","))
                {
                    string[] titulo = Titulo.Split(',');
                    if (titulo.Length == 3)
                    {
                        item = new Extensao(Titulo.Split(',')[1]);
                        item.setAmbiente(Titulo.Split(',')[0]);
                        item.Prioridade = Titulo.Split(',')[2];
                    }
                }
            }

            if (item == null) { item = new Extensao(Titulo); }
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
        public AsteriskCodecConfiguration Codecs { get; } = new AsteriskCodecConfiguration();

        /// <summary>
        /// Telefone que deverá ser binado ao cliente final em chamadas de saída
        /// </summary>
        public string? OutBoundCallerId { get; set; }

        #endregion
    }
}
