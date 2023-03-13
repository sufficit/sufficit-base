using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace Sufficit.Logging
{
    /// <summary>
    /// Long term event registration
    /// </summary>
    public class OldLog : LogBase
    {        
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull | JsonIgnoreCondition.WhenWritingDefault)]
        public new dynamic? Content { get => (string?)base.Content; set => base.Content = value; }

        // Used for entity framework capture from database
        protected string? _content;

        [NotMapped]
        [JsonPropertyName("content")]
        public string? Text { get => _content; set => _content = value; }
    }
}
