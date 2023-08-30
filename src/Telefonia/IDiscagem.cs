using System;

namespace Sufficit.Telefonia
{
    public interface IDiscagem
    {
        string Titulo { get; }
        string Precedencia { get; }
        string Prefixo { get; }
        string Padrao { get; }
    }
}
