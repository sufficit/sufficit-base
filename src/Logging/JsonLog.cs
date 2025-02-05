using System;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace Sufficit.Logging
{
    /// <summary>
    ///     Long term event registration
    /// </summary>
    public class JsonLog : LogBase
    {
        [JsonPropertyName("content")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull | JsonIgnoreCondition.WhenWritingDefault)]
        public virtual string? Content { get; set; }
    }

    /// <summary>
    ///     Long term event registration, content of type T
    /// </summary>
    public class JsonLog<T> : JsonLog where T : class
    {
        /// <summary>
        ///     Property used for web visualization
        /// </summary>
        public bool Visible { get; set; }

        [JsonPropertyName("content")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull | JsonIgnoreCondition.WhenWritingDefault)]
        public string? ContentString {
            get
            {
                if (Content == null) return null;
                return JsonSerializer.Serialize(Content);
            }
            set
            {
                if (value == null) return; 
                Content = JsonSerializer.Deserialize<T>(value);
            }
        }

        [JsonIgnore]
        public new virtual T? Content { get; set; }
    }
}
