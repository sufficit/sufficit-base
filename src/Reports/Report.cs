using System;
using System.Collections.Generic;
using System.Text;

namespace Sufficit.Reports
{
    public abstract class Report : IReportProgress
    {
        #region IMPLEMENT IREPORTPROGRESS
                
        uint IReportProgress.Percentage => progress.Percentage;
        string IReportProgress.Status => progress.Status;
        ReportStepEnum IReportProgress.Step => progress.Step;

        #endregion
        #region CONSTRUCTOR

        public Report(IReportParameters parameters)
        {
            if (parameters == null)
                throw new ArgumentNullException("parameters");

            // Instanciando controle de progresso
            this.progress = new ReportProgress();
            
            this.DTCreation = DateTime.UtcNow;
            this.IDContext = parameters.IDContext;
            this.DTStart = parameters.DTStart;
            this.DTEnd = parameters.DTEnd;
        }

        #endregion
        #region PROPERTIES

        protected ReportProgress progress;
        public IReportProgress Progress => progress;

        #endregion
        #region DEFAULT PARAMETERS

        /// <summary>
        /// Contexto de representação do relatório, cliente ou usuário
        /// </summary>
        public Guid IDContext { get; }

        /// <summary>
        /// Momento de início do relatório
        /// </summary>
        public DateTime DTStart { get; }

        /// <summary>
        /// Momento do término do relatório
        /// </summary>
        public DateTime DTEnd { get; }

        /// <summary>
        /// (UTC) Momento em que foi solicitado o relatório \n
        /// Usado somente para controle
        /// </summary>
        public DateTime DTCreation { get; }

        #endregion
    }
}
