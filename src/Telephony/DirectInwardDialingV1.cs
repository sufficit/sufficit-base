using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Sufficit.Telephony
{
    /// <summary>
    /// DID = Linha de entrada no sistema de telefonia
    /// </summary>
    public class DirectInwardDialingV1 : IDirectInwardDialing, IIndexable
    {
        [Key]
        public string extensao { get; set; }

        public string id { get; set; }
        public string descricao { get; set; }
        public string fornecedor { get; set; }
        public string cliente { get; set; }
        public string tdestino { get; set; }
        public DateTime cadastro { get; set; }
        public string tarifacao { get; set; }
        public string origem { get; set; }
        public string tags { get; set; }
        public string dstclasse { get; set; }
        public string dstid { get; set; }

        #region IMPLEMENTING INTERFACE DIRECT INWARD DIALING

        Guid IDirectInwardDialing.ID => IDResolve(id);
        string IDirectInwardDialing.Dialing => extensao;

        #endregion

        #region IMPLEMENTING INTERFACE INDEXABLE

        Guid IIndex.Id => IDResolve(id);
        Guid IIndexable.ContextId => IDResolve(cliente);
        string IIndexable.Title => extensao;
        string IIndexable.Description => descricao;

        #endregion

        private Guid IDResolve(string s)
        {
            if(Guid.TryParse(s, out var id))
                return id;
            else return Guid.Empty;
        }
    }
}
