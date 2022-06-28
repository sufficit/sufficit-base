using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace Sufficit.Logging
{
    /// <summary>
    /// Long term event registration
    /// </summary>
    public class OldLog : LogBase
    {
        public new string? Content { get => (string?)base.Content; set => base.Content = value; }
    }
}
