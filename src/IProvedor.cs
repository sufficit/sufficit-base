using System;
using System.Collections;
using System.Collections.Generic;

namespace Sufficit
{
    public partial interface IProvedor
    {
        string Titulo { get; }
        Guid IDContexto { get; }
        Guid ID { get; }
        Type[] Classes { get; }
        TProvedor Tipo { get; }
        bool Ativo { get; set; }
        bool Sincronizando { get; }  
        IEnumerable<IIndexavel> Cache { get; }

        #region METODOS

        List<IIndexavel> Buscar(String Texto);
        List<IIndexavel> Buscar(IDictionary Parametros);
        void Atualizar(IDictionary Parametros);
        void Remover(IDictionary Parametros);
        int Incluir(System.Collections.IDictionary Parametros);

        #endregion
    }    
}
