using Sufficit.Exchange;
using System;
using System.Collections.Generic;
using System.Text;
using System.Text.Json.Serialization;

namespace Sufficit.Notification
{
    /// <summary>
    ///     Notifications contacts search
    /// </summary>
    public class ContactSearchParameters
    {
        /// <summary>
        ///     Get only valid or invalid contacts
        /// </summary>
        public bool? Valid { get; set; }

        /// <summary>
        ///     Channel
        /// </summary>
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingDefault)]
        [JsonPropertyName("channel")]
        [JsonConverter(typeof(JsonStringEnumConverter))]
        public TChannel Channel { get; set; }

        /// <summary>
        ///     Filter by destination 
        /// </summary>
        public TextFilter? Destination { get; set; }

        /// <summary>
        ///     Filter by (Destination or Extra or Cause) informations 
        /// </summary>
        public TextFilter? Filter { get; set; }

        /// <summary>
        ///     Contacts (Context | Client | Customer), Id
        /// </summary>
        public Guid? ContextId { get; set; }
    }
}
