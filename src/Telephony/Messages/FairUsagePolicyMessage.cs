using Sufficit.Exchange.Internal;
using System;
using System.Text.Json.Serialization;

namespace Sufficit.Telephony.Messages
{
    /// <summary>
    ///     Occurs when the customer exceeds the maximum call limit in a given period
    /// </summary>
    /// <remarks>*this message is used to trigger the backgroung worker system</remarks>
    public class FairUsagePolicyMessage : InternalMessage
    {
        public const string MODEL_ID = "814ba98e-56ec-4a2f-9cf0-29e30d4f1eb3";

        /// <inheritdoc cref="InternalMessage.ModelId"/>
        [JsonPropertyName("modelid")]
        public override Guid ModelId { get => Guid.Parse(MODEL_ID); }

        /// <summary>
        ///     Context Id
        /// </summary>
        /// <remarks>* respective client</remarks>
        [JsonPropertyName("id")]
        public new Guid Id { get; set; }
    }
}
