using System;
using System.Collections.Generic;
using System.Text;

namespace Sufficit.Configuration
{
    public interface IConfigurationMonitor
    {
        /// <summary>
        /// Habilita ou desabilita o sistema de monitoramento de mudanças nos arquivos de configuração
        /// </summary>
        bool Enabled { get; set; }

        /// <summary>
        /// Estado atual do objeto
        /// </summary>
        string State { get; set; }
    }
}
