using Sufficit.Exchange.Internal;
using System;
using System.Collections.Generic;
using System.Text;
using System.Text.Json.Serialization;
using System.Xml;

namespace Sufficit.Reports
{
    public class ReportMessage : InternalMessage
    {
        public const string MODEL_ID = "ca48c24e-ee23-47a8-8f3a-bc1549a38262";

        /// <inheritdoc cref="InternalMessage.ModelId"/>
        [JsonPropertyName("modelid")]
        public override Guid ModelId { get => Guid.Parse(MODEL_ID); }

        /// <summary>
        ///     Invoice Id
        /// </summary>
        /// <remarks>* respective client billed service, recharge</remarks>
        [JsonPropertyName("id")]
        public new Guid Id { get; set; }
    }
}
