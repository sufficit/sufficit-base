using System;

namespace Sufficit
{
    public interface IIndexavel
    {
        Guid ID { get; }
        String Titulo { get; }
        String Descricao { get; }
    }
}

