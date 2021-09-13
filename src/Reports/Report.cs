using System;
using System.Collections.Generic;
using System.Text;

namespace Sufficit.Reports
{
    public abstract class Report<T> : ReportParameters
    {
        /// <summary>
        /// Resultado a ser exibido deste relatório
        /// </summary>
        public virtual IEnumerable<T> Items { get; protected set; }
    }    
}
