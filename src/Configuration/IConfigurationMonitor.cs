using System;
using System.Collections.Generic;
using System.Text;

namespace Sufficit.Configuration
{
    public interface IConfigurationMonitor
    {
        bool MonitoringEnabled { get; set; }
        string CurrentState { get; set; }
    }
}
