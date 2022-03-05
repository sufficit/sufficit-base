using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sufficit.Logging
{
    public class MemoryLoggerOptions
    {
        public const string SECTIONNAME = "Logging:Memory";

        public int EventId { get; set; } = 0;

        public IDictionary<string, LogLevel> LogLevel { get; set; } = new Dictionary<string, LogLevel>();

        public int Maximum { get; set; } = 0;
    }
}
