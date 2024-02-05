using Sufficit.Exchange;
using System;
using System.Collections.Generic;
using System.Text;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace Sufficit.Notification
{
    public abstract class Event
    {
        [JsonPropertyName("timestamp")]
        public DateTime Timestamp { get; } = DateTime.UtcNow;

        [JsonPropertyName("id")]
        public abstract Guid Id { get; }

        [JsonPropertyName("title")]
        public abstract string Title { get; }

        /// <summary>
        /// Chave de inscrição no evento, não sei ainda se será obrigatório
        /// </summary>
        public virtual string GetKey() => throw new NotImplementedException();

        /// <summary>
        /// Text body for this notification <br />
        /// By default returns a json representation of this object
        /// </summary>
        public virtual ValueTask<string> GetBody (string? extra = null, TChannel channel = default) {
            var json = JsonSerializer.Serialize(this, this.GetType(), Json.Options);
            return new ValueTask<string>(json);
        }

        /// <summary>
        /// Tentativa de dispachar este evento de alguma forma
        /// </summary>
        public virtual Task<bool> TryDispatch()
            => throw new NotImplementedException();        
    }
}
