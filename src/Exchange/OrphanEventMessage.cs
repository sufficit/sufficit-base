using Sufficit.Exchange.Internal;
using System;
using System.Collections.Generic;
using System.Text;
using System.Text.Json.Serialization;
using System.Xml;

namespace Sufficit.Exchange
{
    public class OrphanEventMessage : InternalMessage
    {
        /// <inheritdoc cref="InternalMessage.ModelId"/>
        [JsonPropertyName("modelid")]
        public override Guid ModelId { get => Guid.Parse(Telephony.MailBoxOrphanMessageModel.UniqueID); }

        public OrphanEventMessage(string recipient, string emitter, Guid id = default) : base(id)
        {
            this.Recipient = recipient;
            this.Emitter = emitter;
        }

        public OrphanEventMessage(InternalMessage @internal) : base(@internal.Id)
        {
            this.Recipient = @internal.Recipient;
            this.Emitter = @internal.Emitter;
        }
    }
}
