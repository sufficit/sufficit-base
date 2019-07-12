using System;
using System.Collections.Generic;
using System.Text;

namespace Sufficit.Relacionamento
{
    public class ContatoBase
    {
        #region PROPRIEDADES

        /// <summary>
        /// Identificador exclusivo deste contato
        /// </summary>
        /// <remarks>Tipo de dados GUID uniqueidentifier</remarks>
        /// <value>Guid.NewGuid()</value>
        public Guid ID { get; internal set; }
        
        /// <summary>
        /// Nome para exibição do Contato
        /// </summary>
        public string Titulo { get; set; }

        /// <summary>
        /// Texto com informações para localização, filtro ou pesquisa do objeto
        /// </summary>
        /// <value>String.Empty</value>
        public string Descricao { get; set; }

        /// <summary>
        /// Data / Hora do momento em que foi registrado o contato
        /// </summary>
        /// <value>DateTime.Now()</value>
        public DateTime Cadastro { get; set; }

        /// <summary>
        /// Data / Hora da ultima atualização
        /// </summary>
        public DateTime Alteracao { get; set; }

        #endregion

        public ContatoBase(Guid id, IEnumerable<Atributo> atts)
        {
            ID = id;
            Atributos = atts;
            Titulo = Descricao = string.Empty;
        }

        public virtual IEnumerable<Atributo> Atributos { get; internal set; }
    }
}
