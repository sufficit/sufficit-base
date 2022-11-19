using System;
using System.Collections.Generic;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Sufficit.SSystem
{
    public interface ITask
    {
        /// <summary>
        /// Identificador único de uma tarefa no sistema <br />
        /// Gerado automáticamente Guid.NewGuid()
        /// </summary>
        Guid ID { get; }

        Guid IDContexto { get; set; }

        string Titulo { get; set; }
        string Descricao { get; set; }

        DateTime Instancia { get; }
        DateTime Inicio { get; }
        long Cronometro { get; }

        MethodBase? Origem { get; }

        #region FACILITADORES

        bool IsCompleted { get; }

        TaskStatus Status { get; }

        AggregateException Exception { get; }

        #endregion
    }
}
