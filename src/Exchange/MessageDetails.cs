using Sufficit.Logging;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;
using System.Text.Json.Serialization;

namespace Sufficit.Exchange
{
    /// <summary>
    ///     Used to log details of messages, metadata
    /// </summary>
    public class MessageDetails : LogBaseServerAndTime
    {
        public Guid Id { get; set; }

        public Guid? ContextId { get; set; }

        public Guid? ReferenceId { get; set; }

        public Guid? ModelId { get; set; }

        public string Recipient { get; set; } = default!;

        public TChannel Channel { get; set; } = default!;

        public string? Status { get; set; }

        public JsonException? Exception { get; set; }
    }
}
