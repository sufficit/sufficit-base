using System;
using System.Collections.Generic;
using System.Text;

namespace Sufficit.Web.UI
{
    public interface IUrlParameters
    {
        /// <summary>
        /// Data/Hora de inicio de filtro de conteúdo
        /// </summary>
        DateTime? DTStart { get; }

        /// <summary>
        /// Data/Hora de término de filtro de conteúdo
        /// </summary>
        DateTime? DTEnd { get; }

        /// <summary>
        /// Ajuste de fuso horário em todas as datas da exibição do conteúdo
        /// </summary>
        TimeSpan? OffSet { get; }

        /// <summary>
        /// Guid ID do objeto ao que o conteúdo representa
        /// </summary>
        Guid? ObjectId { get; }
    }
}
