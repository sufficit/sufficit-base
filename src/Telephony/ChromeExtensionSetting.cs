using System;
using System.Text.Json.Serialization;

namespace Sufficit.Telephony
{
    /// <summary>
    /// Key/value store for Chrome softphone settings per user.
    /// Table: telb_chrome (userid, key) → value
    /// </summary>
    public class ChromeExtensionSetting
    {
        [JsonPropertyName("userid")]
        public Guid UserId { get; set; }

        /// <summary>Setting key — see <see cref="ChromeExtensionKeys"/>.</summary>
        [JsonPropertyName("key")]
        public string Key { get; set; } = string.Empty;

        [JsonPropertyName("value")]
        public string? Value { get; set; }
    }
}
