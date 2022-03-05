using System;
using System.Collections.Generic;

namespace Sufficit.Relacionamento
{
    public interface IContato
    {
        Guid ID { get; }
        string Titulo { get; }
        DateTime Atualizacao { get; }

        string Atributo(string Chave);
        System.Collections.Generic.IEnumerable<Atributo> Atributos { get; }
        DateTime Cadastro { get; }
        string EMail { get; }        
        string Referencia { get; }
        string Telefone { get; }

        //System.Collections.Generic.IEnumerable<Guid> IDGrupos { get; set; }
        //bool Grupo { get; }
    }

}
