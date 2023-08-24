using System;
namespace Sufficit.Telefonia
{
    public interface IExtensao
    {
        string Descricao { get; set; }
        Guid IDContexto { get; set; }
        string Titulo { get; set; }

        string ToString();
    }
}
