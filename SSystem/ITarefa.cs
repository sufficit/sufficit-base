using System;
using System.Collections.Generic;
using System.Reflection;
using System.Text;

namespace Sufficit.SSystem
{
    [Obsolete("use ITask instead")]
    public interface ITarefa
    {
        Guid ID { get; set; }

        Guid IDContexto { get; set; }

        string Titulo { get; set; }
        string Descricao { get; set; }

        DateTime Instancia { get; }
        DateTime Inicio { get; }
        long Cronometro { get; }

        MethodBase Origem { get; }
    }
}
