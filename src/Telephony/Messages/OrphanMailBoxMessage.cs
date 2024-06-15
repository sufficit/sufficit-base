using Sufficit.Exchange.Internal;
using System;
using System.Text.Json.Serialization;

namespace Sufficit.Telephony.Messages
{
    /// <summary>
    ///     Occurs on a mailbox hos no valid contacts
    /// </summary>
    /// <remarks>*this message is used to trigger the backgroung worker system</remarks>
    public class OrphanMailBoxMessage : InternalMessage
    {
        public const string MODEL_ID = "20400267-b1bd-469b-90fd-eacdd607eb64";

        /// <inheritdoc cref="InternalMessage.ModelId"/>
        [JsonPropertyName("modelid")]
        public override Guid ModelId { get => Guid.Parse(MODEL_ID); }
    }
}
