﻿using Sufficit.Exchange;
using System;
using System.Collections.Generic;
using System.Text;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.Threading;
using System.Threading.Tasks;

namespace Sufficit.Notification
{
    public abstract class Event
    {
        [JsonPropertyOrder(0)]
        [JsonPropertyName("timestamp")]
        public DateTime Timestamp { get; } = DateTime.UtcNow;

        [JsonPropertyOrder(0)]
        [JsonPropertyName("id")]
        public abstract Guid Id { get; }

        [JsonPropertyOrder(0)]
        [JsonPropertyName("title")]
        public abstract string Title { get; }

        [JsonPropertyOrder(0)]
        [JsonPropertyName("method")]
        [JsonConverter(typeof(JsonStringEnumConverter))]
        public virtual SubscribeMethod Method { get; }

        /// <summary>
        ///     Reference Key of the object that trigger this event
        /// </summary>
        /// <remarks>*will change to Guid soon</remarks>
        public virtual string? GetKey() => null;

        public virtual Guid? GetContextId() => null;

        public virtual Guid? GetReferenceId() => null;

        /// <summary>
        ///     Text body for this notification <br />
        ///     By default returns a json representation of this object
        /// </summary>
        public virtual ValueTask<string> GetBody (string? extra = null, TChannel channel = default) {
            var json = JsonSerializer.SerializeToNode(this, this.GetType());
            if (json != null && !string.IsNullOrWhiteSpace(extra))
                json["extra"] = extra;

            return new ValueTask<string>(json?.ToJsonString() ?? string.Empty);
        }

        /// <summary>
        /// Tentativa de dispachar este evento de alguma forma
        /// </summary>
        public virtual Task<bool> TryDispatch(CancellationToken cancellationToken)
            => throw new NotImplementedException();        
    }
}
