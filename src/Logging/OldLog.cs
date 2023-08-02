using System.Text.Json.Serialization;

namespace Sufficit.Logging
{
    /// <summary>
    /// Long term event registration
    /// </summary>
    public class OldLog : LogBase
    {        
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull | JsonIgnoreCondition.WhenWritingDefault)]
        public string? Content { get; set; }
    }
}
