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
        public string Key { get; set; } = default!;
        public string? HostName { get; set; }
    }
}
