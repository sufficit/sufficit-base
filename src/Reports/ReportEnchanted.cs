using System;
using System.Collections.Generic;

namespace Sufficit.Reports
{
    public abstract class ReportEnchanted : Report
    {
        public ReportEnchanted (IReportParameters parameters) :base(parameters)
        {
            this.ID = Guid.NewGuid();
        }

        /// <summary>
        /// Região padrão de conversão de horários
        /// </summary>
        public TimeZoneInfo TimeZone { get; set; } = TimeZoneInfo.Local;

        #region FACILITADORES

        public virtual IEnumerable<object> Cache { get; }

        /// <summary>
        /// Para não precisar usar o databinder na exibição
        /// </summary>
        public Type Classe => this.GetType();

        /// <summary>
        /// Calculo do total de dias no filtro (FACILITADOR)
        /// </summary>
        public TimeSpan Intervalo
        {
            get
            {
                return (DTEnd - DTStart);
            }
        }

        public Exception Exception { get; set; }

        public Guid ID { get; }

        public virtual string GetFileNamePrefix()
        {
            return $"{ this.GetType().Name }-{ IDContext.ToString("N") }-{ DTStart.ToString("yyyyMMddTHHmm") }-{ DTEnd.ToString("yyyyMMddTHHmm") }";
        }

        #endregion
    }
}
