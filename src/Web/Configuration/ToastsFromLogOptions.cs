using Microsoft.Extensions.Logging;
using Sufficit.Logging;
using System;
using System.Collections.Generic;
using System.Text;

namespace Sufficit.Web.Configuration
{
    public class ToastsFromLogOptions
    {
        public const string SECTIONNAME = "Sufficit:Web:ToastsFromLog";

        /// <summary>
        /// Não sei pra que é usado ainda
        /// </summary>
        public int EventId { get; set; } = 0;

        /// <summary>
        /// Níveis de log que devem gerar toasts
        /// </summary>
        public IDictionary<string, LogLevel> LogLevel { get; set; } = new Dictionary<string, LogLevel>();
    }
}
