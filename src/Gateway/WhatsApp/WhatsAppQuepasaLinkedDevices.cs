using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace Sufficit.Gateway.WhatsApp
{
    /// <summary>
    /// Devices WhatsApp has linked to the account behind one Quepasa session, plus where this
    /// session sits among them.
    ///
    /// The position matters because of a WhatsApp limitation: only the first
    /// <see cref="CallCapableSlots"/> companion devices actually receive calls. A session linked
    /// beyond that keeps working for everything else, so nothing looks broken — messages flow,
    /// the session reports Ready — but calls simply never arrive. Recovering means unlinking
    /// older companions and pairing this one again so it lands in an earlier slot.
    /// </summary>
    public class WhatsAppQuepasaLinkedDevices
    {
        /// <summary>How many companion slots WhatsApp actually delivers calls to.</summary>
        public const int CallCapableSlots = 4;

        [JsonPropertyName("sessionid")]
        public string SessionId { get; set; } = string.Empty;

        /// <summary>False when the device list could not be fetched (session offline, WhatsApp query failed).</summary>
        [JsonPropertyName("success")]
        public bool Success { get; set; }

        /// <summary>Why the list is unavailable, when <see cref="Success"/> is false.</summary>
        [JsonPropertyName("error")]
        public string? Error { get; set; }

        [JsonPropertyName("devices")]
        public List<WhatsAppQuepasaLinkedDevice> Devices { get; set; } = new();

        /// <summary>
        /// This session's 1-based position among the account's COMPANION devices (the phone itself
        /// does not occupy a slot), ordered the way WhatsApp assigns them. 0 when the session could
        /// not be located in the list.
        /// </summary>
        [JsonPropertyName("position")]
        public int Position { get; set; }

        /// <summary>Number of companion devices linked to the account, this session included.</summary>
        [JsonPropertyName("companions")]
        public int Companions { get; set; }

        [JsonPropertyName("queriedat")]
        public DateTime? QueriedAt { get; set; }

        /// <summary>
        /// True when this session sits in a slot WhatsApp does not deliver calls to. The whole
        /// point of this screen: nothing else about the session looks wrong when this happens.
        /// </summary>
        [JsonIgnore]
        public bool CallsBlockedByPosition => Position > CallCapableSlots;
    }

    public class WhatsAppQuepasaLinkedDevice
    {
        /// <summary>WhatsApp-native identifier, e.g. "558000420162:94@s.whatsapp.net".</summary>
        [JsonPropertyName("jid")]
        public string Jid { get; set; } = string.Empty;

        [JsonPropertyName("phone")]
        public string Phone { get; set; } = string.Empty;

        /// <summary>
        /// WhatsApp's device number (the ":94"). Only ever increases and is not reused, so it
        /// identifies a device but says nothing about its position — see
        /// <see cref="WhatsAppQuepasaLinkedDevices.Position"/>.
        /// </summary>
        [JsonPropertyName("deviceid")]
        public int DeviceId { get; set; }

        /// <summary>1-based companion position, or 0 for the phone itself.</summary>
        [JsonPropertyName("position")]
        public int Position { get; set; }

        /// <summary>True for the phone (device 0), which occupies no companion slot.</summary>
        [JsonPropertyName("primary")]
        public bool Primary { get; set; }

        /// <summary>True for the device the inspected session actually is.</summary>
        [JsonPropertyName("current")]
        public bool Current { get; set; }

        /// <summary>True when this device is another session on the same Quepasa deployment.</summary>
        [JsonPropertyName("knownlocally")]
        public bool KnownLocally { get; set; }

        [JsonPropertyName("state")]
        public string? State { get; set; }

        [JsonPropertyName("platform")]
        public string? Platform { get; set; }

        [JsonPropertyName("displayname")]
        public string? DisplayName { get; set; }
    }
}
