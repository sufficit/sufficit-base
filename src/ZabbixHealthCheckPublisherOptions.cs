using System;
using System.Collections.Generic;
using System.Text;

namespace Sufficit
{
    public class ZabbixHealthCheckPublisherOptions
    {
        /// <summary>
        /// Used to configure options
        /// </summary>
        public const string SECTIONNAME = nameof(Sufficit) + ":ZabbixHealthCheckPublisher";

        public string Server { get; set; } = default!;

        /// <summary>
        /// Key to send the health check status to zabbix
        /// </summary>
        public string Key { get; set; } = default!;
        
        /// <summary>
        /// Hostname to send the health check status to zabbix
        /// </summary>
        public string? HostName { get; set; }
    }
}
