using System;
using System.Collections.Generic;
using System.Text;
using System.Text.Json.Serialization;

namespace Sufficit.Notification
{
    /// <summary>
    ///     Contact info + Subscription info
    /// </summary>
    public class Subscriber
    {
        public Subscriber (Contact contact, Subscription subscription)
        {
            Contact = contact; 
            Subscription = subscription;
        }

        [JsonPropertyOrder(0)]
        [JsonPropertyName("contact")]
        public Contact Contact { get; }

        [JsonPropertyOrder(1)]
        [JsonPropertyName("subscription")]
        public Subscription Subscription { get; }

        /// <summary>
        ///     Effective body format: the subscription format, falling back to the contact default
        /// </summary>
        [JsonIgnore]
        public NotificationFormat Format => Subscription?.Format ?? Contact?.Format ?? NotificationFormat.TEXT;

        public static implicit operator Contact (Subscriber s) => s.Contact;
        public static implicit operator Subscription (Subscriber s) => s.Subscription;
    }
}
