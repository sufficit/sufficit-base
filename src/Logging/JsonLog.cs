using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace Sufficit.Logging
{
    /// <summary>
    /// Long term event registration
    /// </summary>
    public class JsonLog : LogBase
    {
        // Used for entity framework capture from database
        private string? _content;

        [NotMapped]
        public new JsonElement Content
        { 
            get
            {
                return JsonSerializer.Deserialize<JsonElement>(string.IsNullOrEmpty(_content) ? "{}" : _content);
            }
            set
            {
                _content = value.ToString();
            }
        }
    }
}
