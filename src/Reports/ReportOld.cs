using System;
using System.Collections.Generic;
using System.Text;

namespace Sufficit.Reports
{
    public abstract class ReportOld<T> : ReportParametersOld
    {
        /// <summary>
        ///     Resultado a ser exibido deste relatório
        /// </summary>
        public virtual IEnumerable<T> Items { get; protected set; } = Array.Empty<T>();
    }    
}
