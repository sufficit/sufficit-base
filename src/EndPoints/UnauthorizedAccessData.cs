using System;
using System.Collections.Generic;
using System.Text;
using System.Text.Json.Serialization;

namespace Sufficit.EndPoints
{
    public class UnauthorizedAccessData
    {
        public string Directive { get; set; } = default!;

        public Guid DirectiveId { get; set; }

        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public Guid? ContextId { get; set; }
    }
}
