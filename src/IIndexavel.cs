using System;

namespace Sufficit
{
    public interface IIndexavel
    {
        Guid ID { get; }
        string Titulo { get; }
        string Descricao { get; }
    }
}

