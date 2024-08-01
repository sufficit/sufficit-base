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

        public static implicit operator Contact (Subscriber s) => s.Contact;
        public static implicit operator Subscription (Subscriber s) => s.Subscription;
    }
}
