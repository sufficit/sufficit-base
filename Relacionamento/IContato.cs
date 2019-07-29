using System;
using System.Collections.Generic;

namespace Sufficit.Relacionamento
{
    public interface IContato
    {
        DateTime Atualizacao { get; }
        string Atributo(string Chave);
        System.Collections.Generic.IEnumerable<Atributo> Atributos { get; }
        DateTime Cadastro { get; }
        string EMail { get; }
        Guid ID { get; }
        
        string Referencia { get; }
        string Telefone { get; }
        string Titulo { get; set; }

        //System.Collections.Generic.IEnumerable<Guid> IDGrupos { get; set; }
        //bool Grupo { get; }
    }

}
