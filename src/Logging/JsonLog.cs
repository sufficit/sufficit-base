using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Text.Json;

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
                string text = string.IsNullOrWhiteSpace(_content) ? "{}" : _content!;
                return JsonSerializer.Deserialize<JsonElement>(text);
            }
            set
            {
                _content = value.ToString();
            }
        }
    }
}
