using System;
using System.Collections.Generic;
using System.Text;
using System.Text.Json.Serialization;

namespace Sufficit.Exchange.EMail
{
    public class EMailMessage : MessageExtended
    {
        [JsonConstructor]
        public EMailMessage(Guid id) : base(id, TChannel.EMAIL) { }


        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingDefault | JsonIgnoreCondition.WhenWritingNull)]
        public string? Subject { get; set; }


        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingDefault)]
        public bool Trackable { get; set; } = true;


        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingDefault | JsonIgnoreCondition.WhenWritingNull)]
        public IEnumerable<MessageAttachment>? Attachements { get; set; }
    }
}
