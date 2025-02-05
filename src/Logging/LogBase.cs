using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace Sufficit.Logging
{
    public abstract class LogBase : LogBaseServerAndTime
    {
        [JsonPropertyName("contextid")]
        public Guid ContextId { get; set; }

        [StringLength(150)]
        [JsonPropertyName("classname")]
        public string ClassName { get; set; } = default!;

        /// <summary>
        ///     Key for object reference, external id
        /// </summary>
        [StringLength(50)]
        [DefaultValue("")]
        [JsonPropertyName("reference")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingDefault)]
        public string Reference { get; set; } = string.Empty;
      

        [StringLength(200)]
        [JsonPropertyName("message")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull | JsonIgnoreCondition.WhenWritingDefault)]
        public string? Message { get; set; }


        [JsonPropertyName("userid")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull | JsonIgnoreCondition.WhenWritingDefault)]
        public Guid? UserId { get; set; }
    }
}
